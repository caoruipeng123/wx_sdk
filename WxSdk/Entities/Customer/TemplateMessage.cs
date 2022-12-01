namespace WxSdk.Entities
{
    /// <summary>
    /// 模板消息发送
    /// </summary>
    public class TemplateMessage
    {
        /// <summary>
        /// 接受者
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 模板Id
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 模板跳转url 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// </summary>
        public Miniprogram miniprogram { get; set; }
        /// <summary>
        /// 模板数据
        /// </summary>
        public object data { get; set; }
    }
    /// <summary>
    /// 跳小程序所需数据，不需跳小程序可不用传该数据
    /// </summary>
    public class Miniprogram
    {
        /// <summary>
        /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系）
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar）
        /// </summary>
        public string pagepath { get; set; }
    }
    public class TemplateData
    {
        /// <summary>
        /// 模板数据值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 模板数据颜色
        /// </summary>
        public string color { get; set; }
    }
}
