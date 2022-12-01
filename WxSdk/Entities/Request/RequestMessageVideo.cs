namespace WxSdk.Entities
{
    public class RequestMessageVideo : RequestMessageBase
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.Video; }
        }

        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
}
