using System;

namespace WxSdk.Entities
{
    /// <summary>
    /// access_token请求后的JSON返回格式
    /// </summary>
    public class AccessTokenResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime expires_time { get; set; }
    }
    /// <summary>
    /// jsapi临时票据返回结果
    /// </summary>
    public class JsApiTicketResult : WxJsonResult
    {
        /// <summary>
        /// 临时票据
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 过期时间，默认7200秒
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 过期时间[后来加上]
        /// </summary>
        public DateTime expires_time { get; set; }
    }
}
