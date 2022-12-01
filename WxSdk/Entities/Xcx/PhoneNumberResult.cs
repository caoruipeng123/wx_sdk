using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxSdk.Entities.Xcx
{
    /// <summary>
    /// 获取用户手机号返回结果
    /// </summary>
    public class PhoneNumberResult:WxJsonResult
    {
        public PhoneInfo phone_info { get; set; }
        public class PhoneInfo
        {
            public string phoneNumber { get; set; }
            public string purePhoneNumber { get; set; }
            public string countryCode { get; set; }
            public WatermarkInfo watermark { get; set; }
        }
        public class WatermarkInfo
        {
            public string appid { get; set; }
            public long timestamp { get; set; }
        }
    }
}
