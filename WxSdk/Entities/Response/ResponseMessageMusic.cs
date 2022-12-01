

namespace WxSdk.Entities
{
    public class ResponseMessageMusic : ResponseMessageBase
    {
        public ResponseMessageMusic()
        {
            Music = new Music();
        }
        public override ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Music; }
        }
        public Music Music { get; set; }
    }
}
