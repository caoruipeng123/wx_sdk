using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using WxSdk.Entities;

namespace WxSdk
{
    public interface IMessageHandler
    {
        /// <summary>
        /// 发送者用户名（OpenId）
        /// </summary>
        string WeixinOpenId { get; }
        /// <summary>
        /// （用户发送给公众号的消息）
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        XDocument RequestDocument { get; set; }
        /// <summary>
        /// （公众号响应给用户的消息）
        /// 根据ResponseMessageBase获得转换后的ResponseDocument
        /// 注意：这里每次请求都会根据当前的ResponseMessageBase生成一次，如需重用此数据，建议使用缓存或局部变量
        /// </summary>
        XDocument ResponseDocument { get; }
        /// <summary>
        /// 请求实体
        /// </summary>
        RequestMessageBase RequestMessage { get; set; }
        /// <summary>
        /// 响应实体
        /// 只有当执行Execute()方法后才可能有值
        /// </summary>
        ResponseMessageBase ResponseMessage { get; set; }

        /// <summary>
        /// 在执行消息处理前需要执行的操作
        /// </summary>
        void OnExecuting();
        /// <summary>
        /// 执行微信请求的消息处理
        /// </summary>
        void Execute();
        /// <summary>
        /// 在执行完消息处理后需要执行的操作
        /// </summary>
        void OnExecuted();
    }

    /// <summary>
    /// 微信请求的集中处理方法
    /// 此方法中所有过程，都基于Senparc.Weixin.MP的基础功能，只为简化代码而设。
    /// </summary>
    public abstract class MessageHandler
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inputStream"></param>
        public MessageHandler(Stream inputStream)
        {
            //StreamReader reader = new StreamReader(inputStream);
            //string body = reader.ReadToEnd();
            //XDocument document = new XDocument(body);
            //Init(document);
            //reader.Close();
            //reader.Dispose();
            using (XmlReader xr = XmlReader.Create(inputStream))
            {
                RequestDocument = XDocument.Load(xr);
                Init(RequestDocument);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestDocument"></param>
        /// <param name="maxRecordCount"></param>
        public MessageHandler(XDocument requestDocument)
        {
            Init(requestDocument);
        }
        /// <summary>
        /// 发送者用户名（OpenId）
        /// </summary>
        public string WeixinOpenId
        {
            get
            {
                if (RequestMessage != null)
                {
                    return RequestMessage.FromUserName;
                }
                return null;
            }
        }
        /// <summary>
        /// 在构造函数中转换得到原始XML数据
        /// </summary>
        public XDocument RequestDocument { get; set; }
        /// <summary>
        /// 根据ResponseMessageBase获得转换后的ResponseDocument
        /// 注意：这里每次请求都会根据当前的ResponseMessageBase生成一次，如需重用此数据，建议使用缓存或局部变量
        /// </summary>
        public XDocument ResponseDocument
        {
            get
            {
                if (ResponseMessage == null)
                {
                    return null;
                }
                return EntityHelper.ConvertEntityToXml(ResponseMessage as ResponseMessageBase);
            }
        }
        /// <summary>
        /// 请求实体
        /// </summary>
        public RequestMessageBase RequestMessage { get; set; }
        /// <summary>
        /// 响应实体
        /// 正常情况下只有当执行Execute()方法后才可能有值。
        /// 也可以结合Cancel，提前给ResponseMessage赋值。
        /// </summary>
        public ResponseMessageBase ResponseMessage { get; set; }
        /// <summary>
        /// 在执行消息处理前需要执行的操作，视具体业务需求重写此方法
        /// </summary>
        public virtual void OnExecuting()
        {
        }
        /// <summary>
        /// 执行微信请求的消息处理
        /// </summary>
        public void Execute()
        {
            OnExecuting();
            try
            {
                if (RequestMessage == null)
                {
                    return;
                }
                switch (RequestMessage.MsgType)
                {
                    case RequestMsgType.Text:
                        ResponseMessage = OnTextRequest(RequestMessage as RequestMessageText);
                        break;
                    case RequestMsgType.Location:
                        ResponseMessage = OnLocationRequest(RequestMessage as RequestMessageLocation);
                        break;
                    case RequestMsgType.Image:
                        ResponseMessage = OnImageRequest(RequestMessage as RequestMessageImage);
                        break;
                    case RequestMsgType.Voice:
                        ResponseMessage = OnVoiceRequest(RequestMessage as RequestMessageVoice);
                        break;
                    case RequestMsgType.Video:
                        ResponseMessage = OnVideoRequest(RequestMessage as RequestMessageVideo);
                        break;
                    case RequestMsgType.Event:
                        ResponseMessage = OnEventRequest(RequestMessage as RequestMessageEventBase);
                        break;
                    case RequestMsgType.Link:
                        ResponseMessage = OnLinkRequest(RequestMessage as RequestMessageLink);
                        break;
                    default:
                        throw new UnknownRequestMsgTypeException("未知的MsgType请求类型", null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                OnExecuted();
            }
        }
        /// <summary>
        /// 在执行完消息处理后需要执行的操作，视具体业务需求重写此方法
        /// </summary>
        public virtual void OnExecuted()
        {
        }

        /// <summary>
        /// 将用户发送消息的XML数据包转换为数据实体
        /// </summary>
        /// <param name="requestDocument"></param>
        private void Init(XDocument requestDocument)
        {
            RequestDocument = requestDocument;
            //将XML数据包转换为数据实体（将用户的请求XML数据转换为请求实体对象）
            RequestMessage = RequestMessageFactory.GetRequestEntity(RequestDocument);
        }

        /// <summary>
        /// 根据当前的RequestMessage创建指定类型的ResponseMessage
        /// </summary>
        /// <typeparam name="TR">基于ResponseMessageBase的响应消息类型</typeparam>
        /// <returns></returns>
        protected TR CreateResponseMessage<TR>() where TR : ResponseMessageBase
        {
            if (RequestMessage == null)
            {
                return null;
            }
            return RequestMessage.CreateResponseMessage<TR>();
        }

        /// <summary>
        /// 默认返回消息
        /// </summary>
        protected virtual ResponseMessageBase DefaultResponseMessage(RequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "我们已收到您发送的消息，感谢您对百雀家医的支持。";
            return responseMessage;
        }
        #region 每种类型的消息处理方法，视具体业务需求重写每个方法
        /// <summary>
        /// 文字类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// 位置类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// 图片类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// 语音类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// 视频类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// 链接消息类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求
        /// </summary>
        protected virtual ResponseMessageBase OnEventRequest(RequestMessageEventBase requestMessage)
        {
            var strongRequestMessage = RequestMessage as RequestMessageEventBase;
            ResponseMessageBase responseMessage = null;
            switch (strongRequestMessage.Event)
            {
                case Event.LOCATION://自动发送的用户当前位置
                    responseMessage = OnEvent_LocationRequest(RequestMessage as RequestMessageEvent_Location);
                    break;
                case Event.subscribe://订阅
                    responseMessage = OnEvent_SubscribeRequest(RequestMessage as RequestMessageEvent_Subscribe);
                    break;
                case Event.unsubscribe://退订
                    responseMessage = OnEvent_UnsubscribeRequest(RequestMessage as RequestMessageEvent_Unsubscribe);
                    break;
                case Event.CLICK://菜单点击
                    responseMessage = OnEvent_ClickRequest(RequestMessage as RequestMessageEvent_Click);
                    break;
                case Event.VIEW://菜单点击[链接跳转]
                    responseMessage = OnEvent_ViewRequest(RequestMessage as RequestMessageEvent_View);
                    break;
                case Event.scan://二维码
                    responseMessage = OnEvent_ScanRequest(RequestMessage as RequestMessageEvent_Scan);
                    break;
                case Event.TEMPLATESENDJOBFINISH://模板消息发送完毕
                    responseMessage = OnEvent_TemplateRequest(RequestMessage as RequestMessageEvent_TemplateSend);
                    break;
                default:
                    throw new UnknownRequestMsgTypeException("未知的Event下属请求信息", null);
            }
            return responseMessage;
        }
        #endregion
        #region 每种事件消息处理方法，视具体业务需求重写每个方法
        /// <summary>
        /// Event事件类型请求之LOCATION
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之subscribe
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之unsubscribe
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之CLICK
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之View
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之扫描带参数二维码
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        /// <summary>
        /// Event事件类型请求之模板消息发送完成
        /// </summary>
        protected virtual ResponseMessageBase OnEvent_TemplateRequest(RequestMessageEvent_TemplateSend requestMessage)
        {
            return DefaultResponseMessage(requestMessage);
        }
        #endregion
    }
}
