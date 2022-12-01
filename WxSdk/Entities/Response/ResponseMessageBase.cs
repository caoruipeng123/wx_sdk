namespace WxSdk.Entities
{
    /// <summary>
    /// 公众号回复消息基类
    /// </summary>
    public class ResponseMessageBase : MessageBase
    {
        /// <summary>
        /// 公众号回复消息类型
        /// </summary>
        public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Text; }
        }
    }
}
