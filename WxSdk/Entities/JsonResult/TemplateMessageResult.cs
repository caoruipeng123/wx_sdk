namespace WxSdk.Entities
{
    public class TemplateMessageResult : WxJsonResult
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public string msgid { get; set; }
    }
    public class MassMessageResult : WxJsonResult
    {
        ///// <summary>
        ///// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），图文消息为news
        ///// </summary>
        //public string type { get; set; }
        /// <summary>
        /// 消息发送任务的ID
        /// </summary>
        public string msg_id { get; set; }
        /// <summary>
        /// 消息的数据ID，该字段只有在群发图文消息时，才会出现。可以用于在图文分析数据接口中，获取到对应的图文消息的数据，是图文分析数据接口中的msgid字段中的前半部分，详见图文分析数据接口中的msgid字段的介绍。
        /// </summary>
        public string msg_data_id { get; set; }
    }
}
