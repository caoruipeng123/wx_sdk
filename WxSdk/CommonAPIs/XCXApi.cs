using WxSdk.Entities;
using WxSdk.Entities.Xcx;

namespace WxSdk
{
    /// <summary>
    /// 小程序Api接口
    /// </summary>
    public class XCXApi
    {
        /// <summary>
        /// 获取小程序的登录信息
        /// </summary>
        /// <param name="appId">小程序appid</param>
        /// <param name="secret">小程序秘钥</param>
        /// <param name="jsCode">登录code</param>
        /// <returns></returns>
        public static OAuthResult GetOAuthResult(string appId, string secret, string jsCode)
        {
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={jsCode}&grant_type=authorization_code";
            string result = RequestUtility.HttpGet(url, null);
            return ApiHelper.GetResult<OAuthResult>(result);
        }

        /// <summary>
        /// 检查加密信息是否由微信生成（当前只支持手机号加密数据）
        /// </summary>
        /// <param name="accessToken">小程序接口调用Token</param>
        /// <param name="encryptedMsgHash">加密数据的sha256，通过Hex（Base16）编码后的字符串</param>
        public static CheckEncryptedDataResult CheckEncryptedData(string accessToken, string encryptedMsgHash)
        {
            var url = "https://api.weixin.qq.com/wxa/business/checkencryptedmsg?access_token={0}";
            var result = ApiHelper.Post<CheckEncryptedDataResult>(accessToken, url, new { encrypted_msg_hash = encryptedMsgHash });
            return result;
        }

        /// <summary>
        /// 获取小程序用户手机号
        /// </summary>
        /// <param name="accessToken">接口调用token</param>
        /// <param name="code">手机号换取凭证</param>
        /// <returns></returns>
        public static PhoneNumberResult GetPhoneNumber(string accessToken,string code)
        {
            string url = "https://api.weixin.qq.com/wxa/business/getuserphonenumber?access_token={0}";
            var result = ApiHelper.Post<PhoneNumberResult>(accessToken, url, new { code = code });
            return result;
        }
    }
}
