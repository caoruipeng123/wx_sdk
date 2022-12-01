//using System.IO;
//using System.Text;
//using WxApiSdk.Entities;

//namespace WxApiSdk
//{
//    /// <summary>
//    /// 自定义message处理类，该类仅供参考，实际开发中可实现自己的message处理类
//    /// </summary>
//    public class CustomMessageHandler : MessageHandler
//    {
//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="inputStream"></param>
//        /// <param name="maxRecordCount"></param>
//        public CustomMessageHandler(Stream inputStream) : base(inputStream) { }
//        ///// <summary>
//        ///// 文字类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();

//        //    var result = new StringBuilder();
//        //    result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content); result.AppendLine("\r\n");
//        //    result.AppendLine("您还可以发送【位置】【图片】【语音】【视频】等类型的信息（注意是这几种类型，不是这几个文字），查看不同格式的回复。");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //}
//        ///// <summary>
//        ///// 图片类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.AppendFormat("您刚才发送了图片信息"); result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //    //var responseMessage = CreateResponseMessage<ResponseMessageImage>();
//        //    //responseMessage.Image = new Image() { MediaId = "cRPKyfpw5kvI4wD9gIrKGrTV5hB9XnngdtfNu_g2Hqy_zie2teVSfYfO6lTHpBGi" };
//        //    //return responseMessage;
//        //}
//        ///// <summary>
//        ///// 语音类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.AppendFormat("您刚才发送了语音信息"); result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //    //var responseMessage = CreateResponseMessage<ResponseMessageVoice>();
//        //    //responseMessage.Voice = new Voice() { MediaId = "Bus48xJIhEG6i8-E_VTGaw-a-YtO3-mnKaswx0LQM9E" };
//        //    //return responseMessage;
//        //}
//        ///// <summary>
//        ///// 视频类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
//        //{
//        //    //var responseMessage = CreateResponseMessage<ResponseMessageVideo>();//被动回复视频信息
//        //    //responseMessage.Video = new Video() {  MediaId= "Bus48xJIhEG6i8-E_VTGa40QGoWCMRGhPMHomKbGF64" };
//        //    //return responseMessage;
//        //    //var responseMessage = CreateResponseMessage<ResponseMessageMusic>();//被动回复音乐消息
//        //    //responseMessage.Music = new Music() { Title = "音乐标题", Description = "音乐描述", MusicUrl = "http://www.baidu.com", HQMusicUrl = "http://www.baidu.com" };
//        //    //return responseMessage;
//        //    //var responseMessage = CreateResponseMessage<ResponseMessageNews>();//被动回复图文消息
//        //    //responseMessage.ArticleCount = 1;
//        //    //responseMessage.Articles = new List<Article>() { new Article()
//        //    //{
//        //    //    Title="文章标题", Description="文章描述", PicUrl="http://www.baidu.com", Url="http://www.baidu.com"
//        //    //}};
//        //    //return responseMessage;
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.AppendFormat("您刚才发送了视频信息"); result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //}
//        ///// <summary>
//        ///// 地理位置类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.Append($"您刚才发送了一个地理位置消息,坐标X：{requestMessage.Location_X}，坐标Y：{requestMessage.Location_Y}");
//        //    result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //}
//        ///// <summary>
//        ///// 链接类型请求
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.Append($"您刚才发送了一个链接地址,Url:{requestMessage.Url}\r\n Title:{requestMessage.Title}\r\nDescription:{requestMessage.Description}");
//        //    result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //}

//        /// <summary>
//        /// Event事件类型请求之关注订阅号
//        /// </summary>
//        /// <param name="requestMessage"></param>
//        /// <returns></returns>
//        protected override ResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
//        {
//            var responseMessage = CreateResponseMessage<ResponseMessageText>();
//            var result = new StringBuilder();
//            result.AppendFormat("感谢您关注我们的公众号~~");
//            responseMessage.Content = result.ToString();
//            return responseMessage;
//        }
//        ///// <summary>
//        ///// Event事件类型请求之取消关注
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
//        //{
//        //    Console.WriteLine($"用户{requestMessage.FromUserName}已取消关注该订阅号！");
//        //    return null;
//        //}
//        ///// <summary>
//        ///// Event事件类型请求之上报地理位置
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
//        //{
//        //    return base.OnEvent_LocationRequest(requestMessage);
//        //}
//        ///// <summary>
//        ///// Event事件类型请求之扫描带参数二维码
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
//        //{
//        //    return base.OnEvent_ScanRequest(requestMessage);
//        //}
//        ///// <summary>
//        ///// Event事件类型请求之菜单点击
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
//        //{
//        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
//        //    var result = new StringBuilder();
//        //    result.Append($"你刚才点击了按钮,key:{requestMessage.EventKey}");
//        //    result.AppendLine("\r\n");
//        //    responseMessage.Content = result.ToString();
//        //    return responseMessage;
//        //}
//        ///// <summary>
//        ///// Event事件类型请求之链接菜单点击
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
//        //{
//        //    Console.WriteLine("Event事件类型请求之链接菜单点击");
//        //    return null;
//        //}
//        ///// <summary>
//        ///// Event事件类型请求之模板消息发送完成
//        ///// </summary>
//        ///// <param name="requestMessage"></param>
//        ///// <returns></returns>
//        //protected override ResponseMessageBase OnEvent_TemplateRequest(RequestMessageEvent_TemplateSend requestMessage)
//        //{ 
//        //    Console.WriteLine(requestMessage.Status);
//        //    return null;
//        //}
//    }
//}