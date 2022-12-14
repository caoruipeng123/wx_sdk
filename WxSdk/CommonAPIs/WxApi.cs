using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using WxSdk.Entities;

namespace WxSdk
{
    /// <summary>
    /// 微信公众号开发接口
    /// </summary>
    public static partial class MPApi
    {
        #region 获取凭证接口
        /// <summary>
        /// 获取凭证接口
        /// </summary>
        /// <param name="grant_type">获取access_token填写client_credential</param>
        /// <param name="appid">第三方用户唯一凭证</param>
        /// <param name="secret">第三方用户唯一凭证密钥，既appsecret</param>
        /// <returns></returns>
        public static AccessTokenResult GetToken(string appid, string secret, string grant_type = "client_credential")
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
                                    grant_type, appid, secret);
            string result = RequestUtility.HttpGet(url, null);
            return ApiHelper.GetResult<AccessTokenResult>(result);
        }
        #endregion

        #region 菜单管理
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="buttonData">菜单内容</param>
        /// <returns></returns>
        public static WxJsonResult CreateMenu(string accessToken, ButtonGroup buttonData)
        {
            //微信公众平台创建自定义菜单接口地址
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
            return ApiHelper.Post(accessToken, urlFormat, buttonData);
        }

        /// <summary>
        /// 获取当前菜单，如果菜单不存在，将返回null
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GetMenuResult GetMenu(string accessToken)
        {
            //微信公众平台获取自定义菜单接口地址
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            var jsonString = RequestUtility.HttpGet(url, Encoding.UTF8);
            GetMenuResult finalResult;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                //获取自定义菜单Json结构
                var jsonResult = JsonConvert.DeserializeObject<GetMenuResultJson>(jsonString);
                if (jsonResult.menu == null || jsonResult.menu.button.Count == 0)
                {
                    throw new WeixinException(jsonResult.ErrMsg);
                }
                //将Json结构自定义菜单转换为自定义菜单实体
                finalResult = GetMenuFromJsonResult(jsonResult);
            }
            catch (WeixinException)
            {
                finalResult = null;
            }
            return finalResult;
        }

        /// <summary>
        /// 根据微信返回的Json数据得到可用的GetMenuResult结果
        /// 将Json结构自定义菜单转换为自定义菜单实体
        /// </summary>
        /// <param name="resultFull"></param>
        /// <returns></returns>
        private static GetMenuResult GetMenuFromJsonResult(GetMenuResultJson resultFull)
        {
            GetMenuResult result = null;
            try
            {
                ButtonGroup bg = new ButtonGroup();
                //循环遍历Json结构
                foreach (var rootButton in resultFull.menu.button)
                {
                    if (rootButton.name == null)
                    {
                        continue;//没有设置一级菜单
                    }
                    //可用二级菜单按钮数量
                    var availableSubButton = rootButton.sub_button.Count(z => !string.IsNullOrEmpty(z.name));
                    //一级菜单格式转换
                    if (availableSubButton == 0)
                    {
                        //按钮格式校验
                        if (rootButton.type == null ||
                            (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                            && string.IsNullOrEmpty(rootButton.key)))
                        {
                            throw new WeixinMenuException("单击按钮的key不能为空！");
                        }
                        if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                        {
                            //底部单击按钮
                            bg.button.Add(new SingleClickButton()
                            {
                                name = rootButton.name,
                                key = rootButton.key,
                                type = rootButton.type
                            });
                        }
                        else
                        {
                            //底部URL按钮
                            bg.button.Add(new SingleViewButton()
                            {
                                name = rootButton.name,
                                url = rootButton.url,
                                type = rootButton.type
                            });
                        }
                    }
                    else if (availableSubButton < 1)
                    {
                        throw new WeixinMenuException("子菜单至少需要填写1个！");
                    }
                    //二级菜单格式转换
                    else
                    {
                        //底部二级菜单
                        var subButton = new SubButton(rootButton.name);
                        bg.button.Add(subButton);
                        foreach (var subSubButton in rootButton.sub_button)
                        {
                            if (subSubButton.name == null)
                            {
                                continue; //没有设置菜单
                            }
                            //按钮格式校验
                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                                && string.IsNullOrEmpty(subSubButton.key))
                            {
                                throw new WeixinMenuException("单击按钮的key不能为空！");
                            }
                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                            {
                                //底部单击按钮
                                subButton.sub_button.Add(new SingleClickButton()
                                {
                                    name = subSubButton.name,
                                    key = subSubButton.key,
                                    type = subSubButton.type
                                });
                            }
                            else
                            {
                                //底部URL按钮
                                subButton.sub_button.Add(new SingleViewButton()
                                {
                                    name = subSubButton.name,
                                    url = subSubButton.url,
                                    type = subSubButton.type
                                });
                            }
                        }
                    }
                }
                if (bg.button.Count < 1)
                {
                    throw new WeixinMenuException("一级菜单按钮至少为1个！");
                }
                //保存到自定义菜单实体
                result = new GetMenuResult()
                {
                    menu = bg
                };
            }
            catch (Exception ex)
            {
                throw new WeixinMenuException(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WxJsonResult DeleteMenu(string accessToken)
        {
            //微信公众平台删除自定义菜单接口地址
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
            var result = ApiHelper.Get(accessToken, urlFormat);
            return result;
        }
        #endregion

        #region 其他
        /// <summary>
        /// 获取jsapi_ticket[曹瑞鹏]
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <returns></returns>
        public static JsApiTicketResult GetJsApiTicket(string access_token)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            return ApiHelper.Get<JsApiTicketResult>(access_token, urlFormat);
        }

        /// <summary>
        /// 获取jsapi签名[曹瑞鹏]
        /// </summary>
        /// <param name="jsapi_ticket">jsapi临时票据</param>
        /// <param name="noncestr">随机字符串</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分</param>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static string GetJsApiSign(string jsapi_ticket, string noncestr, string url, string timestamp, out string s)
        {
            string str = $"jsapi_ticket={jsapi_ticket}&noncestr={noncestr}&timestamp={timestamp}&url={url}";
            string sign = WxApiHelper.SHA1(str).ToLower();
            s = str;
            return sign;
        }
        #endregion
    }
}
