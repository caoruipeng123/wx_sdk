namespace WxSdk.Entities
{
    public class RequestMessageEvent_Scan : RequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.scan; }
        }
        /// <summary>
        /// 二维码的参数
        /// </summary>
        public string Ticket { get; set; }
    }
}
