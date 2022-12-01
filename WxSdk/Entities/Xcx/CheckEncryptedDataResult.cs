using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxSdk.Entities.Xcx
{
    /// <summary>
    /// 检查加密信息是否由微信生成（当前只支持手机号加密数据），只能检测最近3天生成的加密数据
    /// </summary>
    public class CheckEncryptedDataResult : WxJsonResult
    {
        /// <summary>
        /// 是否是合法的数据
        /// </summary>
        [JsonProperty("vaild")]
        public bool Vaild { get;set;}
        /// <summary>
        /// 加密数据生成的时间戳
        /// </summary>
        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
