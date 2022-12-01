namespace WxSdk.Entities
{
    public class RequestMessageEvent_Subscribe : RequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.subscribe; }
        }
    }
}
