namespace WxSdk.Entities
{
    public class RequestMessageEvent_Click : RequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.CLICK; }
        }
    }
    public class RequestMessageEvent_View : RequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.VIEW; }
        }
    }
    /// <summary>
    /// 模板消息发送完毕推送
    /// </summary>
    public class RequestMessageEvent_TemplateSend : RequestMessageEventBase
    {
        public override Event Event
        {
            get
            {
                return Event.TEMPLATESENDJOBFINISH;
            }
        }
        /// <summary>
        /// 发送状态
        /// </summary>
        public string Status { get; set; }
    }
    public class RequestMessageEvent_MassSend : RequestMessageEventBase
    {
        public override Event Event
        {
            get
            {
                return Event.MASSSENDJOBFINISH;
            }
        }
        public string MsgID { get; set; }
        public string Status { get; set; }
        public int TotalCount { get; set; }
        public int FilterCount { get; set; }
        public int SentCount { get; set; }
        public int ErrorCount { get; set; }
        public CopyrightCheckResult CopyrightCheckResult { get; set; }

    }
    public class CopyrightCheckResult
    {
        public int Count { get; set; }
        public object ResultList { get; set; }
        public string CheckState { get; set; }
    }
}
