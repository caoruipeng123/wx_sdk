using System.Collections.Generic;
using System.Linq;
using WxSdk.Entities;

namespace WxSdk
{
    /// <summary>
    /// 客服接口
    /// </summary>
    public static partial class MPApi
    {
        /// <summary>
        /// 微信公众平台客服接口地址
        /// </summary>
        private const string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
       
        /// <summary>
        /// 群发消息接口地址
        /// </summary>
        private const string URL_MASS_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";
       
        #region ...............发送客服消息.................
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="content">要发送的文字信息</param>
        /// <returns></returns>
        public static WxJsonResult SendText(string accessToken, string openId, string content)
        {
            var data = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }

        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="mediaId">已上传到微信的图片文件ID</param>
        /// <returns></returns>
        public static WxJsonResult SendImage(string accessToken, string openId, string mediaId)
        {
            var data = new
            {
                touser = openId,
                msgtype = "image",
                image = new
                {
                    media_id = mediaId
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }

        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="mediaId">已上传到微信的语音文件ID</param>
        /// <returns></returns>
        public static WxJsonResult SendVoice(string accessToken, string openId, string mediaId)
        {
            var data = new
            {
                touser = openId,
                msgtype = "voice",
                voice = new
                {
                    media_id = mediaId
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }

        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="mediaId">已上传到微信的视频文件ID</param>
        /// <param name="title">视频消息的标题（非必须）</param>
        /// <param name="description">视频消息的描述（非必须）</param>
        /// <returns></returns>
        public static WxJsonResult SendVideo(string accessToken, string openId, string mediaId, string title, string description)
        {
            var data = new
            {
                touser = openId,
                msgtype = "video",
                video = new
                {
                    media_id = mediaId,
                    title = title,
                    description = description
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }
       
        /// <summary>
        /// 发送音乐消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="title">音乐标题（非必须）</param>
        /// <param name="description">音乐描述（非必须）</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="hqMusicUrl">高品质音乐链接，wifi环境优先使用该链接播放音乐</param>
        /// <param name="thumbMediaId">缩略图的媒体ID</param>
        /// <returns></returns>
        public static WxJsonResult SendMusic(string accessToken, string openId, string title, string description, string musicUrl, string hqMusicUrl, string thumbMediaId)
        {
            var data = new
            {
                touser = openId,
                msgtype = "music",
                music = new
                {
                    title = title,
                    description = description,
                    musicurl = musicUrl,
                    hqmusicurl = hqMusicUrl,
                    thumb_media_id = thumbMediaId
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }
      
        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">接收消息的用户OpenId</param>
        /// <param name="articles">图文消息实体，图文消息条数限制在10条以内</param>
        /// <returns></returns>
        public static WxJsonResult SendNews(string accessToken, string openId, List<Article> articles)
        {
            var data = new
            {
                touser = openId,
                msgtype = "news",
                news = new
                {
                    articles = articles.Select(z => new
                    {
                        title = z.Title,//标题
                        description = z.Description,//描述
                        url = z.Url,//点击后跳转的链接
                        picurl = z.PicUrl//图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80
                    }).ToList()
                }
            };
            return ApiHelper.Post(accessToken, URL_FORMAT, data);
        }
       
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="content"></param>
        public static TemplateMessageResult SendTemplateMessage(string accessToken, object content)
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
            return ApiHelper.Post<TemplateMessageResult>(accessToken, urlFormat, content);
        }
      
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="touser">消息接受者</param>
        /// <param name="template_id">模板消息id</param>
        /// <param name="url">模板消息跳转链接</param>
        /// <param name="data">末班消息数据</param>
        /// <returns></returns>
        public static TemplateMessageResult SendTemplateMessage(string access_token, string touser, string template_id, string url, object data)
        {
            if (!string.IsNullOrWhiteSpace(access_token))
            {
                TemplateMessage model = new TemplateMessage();
                model.touser = touser;
                model.template_id = template_id;
                model.url = url;
                model.miniprogram = null;
                model.data = data;
                TemplateMessageResult result = SendTemplateMessage(access_token, model);
                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 群发消息

        /// <summary>
        /// 根据OpenId列表群发文本消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openIds">接受群发消息的openid集合</param>
        /// <param name="content">群发消息内容</param>
        /// <returns></returns>
        public static MassMessageResult SensMassTextByOpenIds(string accessToken, List<string> openIds, string content)
        {
            var data = new
            {
                touser = openIds,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            return ApiHelper.Post<MassMessageResult>(accessToken, URL_MASS_FORMAT, data);
        }
        #endregion
        #region ...............客服账号管理.................
        /// <summary>
        /// 新增客服账号
        /// </summary>
        /// <param name="model">客服账号实体</param>
        /// <returns></returns>
        public static WxJsonResult AddCustom(string accessToken, CustomAccount model)
        {
            return ApiHelper.Post(accessToken, StaticUrl.URL_AddCustom, model);
        }

        /// <summary>
        /// 修改客服账号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static WxJsonResult UpdateCustom(string accessToken, CustomAccount model)
        {
            return ApiHelper.Post(accessToken, StaticUrl.URL_UpdateCustom, model);
        }

        /// <summary>
        /// 删除客服账号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static WxJsonResult DeleteCustom(string accessToken, CustomAccount model)
        {
            string param = string.Format("&kf_account={0}&nickname={1}&password={2}", model.kf_account, model.nickname, model.password);
            //string result = RequestUtility.HttpGet(StaticUrl.URL_DeleteCustom + param, null);
            //return ApiHelper.GetResult<WxJsonResult>(result);
            return ApiHelper.Get(accessToken, StaticUrl.URL_DeleteCustom + param, new string[0]);
        }

        /// <summary>
        /// 设置客服头像地址
        /// </summary>
        /// <returns></returns>
        public static string SetCustomImage()
        {

            return null;
        }

        /// <summary>
        /// 获取所有客服账号信息
        /// </summary>
        /// <returns></returns>
        public static CustomAll GetAllCustom(string accessToken)
        {
            return ApiHelper.Get<CustomAll>(accessToken, StaticUrl.URL_GetAllCustom, new string[0]);
        }
        #endregion
    }
}
