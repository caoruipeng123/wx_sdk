namespace WxSdk.Entities
{
    public class ResponseMessageText : ResponseMessageBase
    {
        new public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Text; }
        }
        public string Content { get; set; }
    }
}
