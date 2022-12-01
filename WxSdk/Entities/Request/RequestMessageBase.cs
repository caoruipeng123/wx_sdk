

namespace WxSdk.Entities
{
    /// <summary>
    /// 用户发送消息基类
    /// </summary>
    public class RequestMessageBase : MessageBase
    {
        /// <summary>
        /// 用户发送消息类型
        /// </summary>
        public virtual RequestMsgType MsgType
        {
            get { return RequestMsgType.Text; }
        }
        /// <summary>
        /// 消息ID
        /// </summary>
        public long MsgId { get; set; }
    }
}
