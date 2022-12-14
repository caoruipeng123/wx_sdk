using System;

namespace WxSdk.Entities
{
    /// <summary>
    /// 所有Request和Response消息的基类
    /// </summary>
    public class MessageBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
