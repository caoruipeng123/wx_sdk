namespace WxSdk.Entities
{
    public class RequestMessageEvent_Unsubscribe : RequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.unsubscribe; }
        }
    }
}
