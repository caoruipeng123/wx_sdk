namespace WxSdk.Entities
{
    public class RequestMessageImage : RequestMessageBase
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.Image; }
        }

        public string MediaId { get; set; }
        public string PicUrl { get; set; }
    }
}
