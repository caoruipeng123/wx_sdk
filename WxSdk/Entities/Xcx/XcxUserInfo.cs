using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxSdk.Entities.Xcx
{
    /// <summary>
    /// 小程序用户信息
    /// </summary>
    public class XcxUserInfo
    {
        /// <summary>
        /// 小程序OpenId
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 开放平台Id
        /// </summary>
        public string unionId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }
        public WatermarkInfo watermark { get; set; }
        public class WatermarkInfo
        {
            /// <summary>
            /// 小程序appid
            /// </summary>
            public string appid { get; set; }
            /// <summary>
            /// 时间戳
            /// </summary>
            public long timestamp { get; set; }
        }
    }
}
