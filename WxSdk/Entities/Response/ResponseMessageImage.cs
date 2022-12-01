namespace WxSdk.Entities
{
    public class ResponseMessageImage : ResponseMessageBase
    {
        new public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Image; }
        }
        public Image Image { get; set; }

    }
}
