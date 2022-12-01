using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WxSdk.Entities
{
    public class OAuthResult:WxJsonResult
    {
        /// <summary>
        /// openid
        /// </summary>
        [JsonProperty("openid")]
        public string OpenID { get; set; }
        /// <summary>
        /// 会话秘钥
        /// </summary>
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }
        /// <summary>
        /// 开放平台
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionID { get; set; }
    }
}
