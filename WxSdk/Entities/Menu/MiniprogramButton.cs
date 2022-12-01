using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxSdk.Entities
{
    /// <summary>
    /// 小程序链接按钮
    /// </summary>
    public class MiniprogramButton : SingleButton
    {
        /// <summary>
        /// 网页 链接，用户点击菜单可打开链接，不超过1024字节。 type为miniprogram时，不支持小程序的老版本客户端将打开本url。
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 小程序的appid（仅认证公众号可配置）
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 小程序页面路径
        /// </summary>
        public string pagepath { get; set; }

        public MiniprogramButton()
            : base(ButtonType.miniprogram.ToString())
        {
        }
    }
}
