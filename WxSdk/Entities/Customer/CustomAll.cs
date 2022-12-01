using System.Collections.Generic;

namespace WxSdk.Entities
{
    public class CustomAll
    {
        public List<Custom> kf_list { get; set; }
        public CustomAll()
        {
            kf_list = new List<Custom>();
        }
    }
    public class Custom
    {
        /// <summary>
        /// 客服账号
        /// </summary>
        public string kf_account { get; set; }
        /// <summary>
        /// 客服头像url地址
        /// </summary>
        public string kf_headimgurl { get; set; }
        /// <summary>
        /// 客服Id
        /// </summary>
        public string kf_id { get; set; }
        /// <summary>
        /// 客服昵称
        /// </summary>
        public string kf_nick { get; set; }
        /// <summary>
        /// 客服绑定的微信号
        /// </summary>
        public string kf_wx { get; set; }
    }
}
