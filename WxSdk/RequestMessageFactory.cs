using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using WxSdk.Entities;

namespace WxSdk
{

    public static class RequestMessageFactory
    {
        /// <summary>
        /// 获取XDocument转换后的IRequestMessageBase实例。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <returns></returns>
        public static RequestMessageBase GetRequestEntity(XDocument doc)
        {
            RequestMessageBase requestMessage = null;
            RequestMsgType msgType;
            try
            {
                msgType = MsgTypeHelper.GetRequestMsgType(doc);
                switch (msgType)
                {
                    case RequestMsgType.Text:
                        requestMessage = new RequestMessageText();
                        break;
                    case RequestMsgType.Location:
                        requestMessage = new RequestMessageLocation();
                        break;
                    case RequestMsgType.Image:
                        requestMessage = new RequestMessageImage();
                        break;
                    case RequestMsgType.Voice:
                        requestMessage = new RequestMessageVoice();
                        break;
                    case RequestMsgType.Video:
                        requestMessage = new RequestMessageVideo();
                        break;
                    case RequestMsgType.Link:
                        requestMessage = new RequestMessageLink();
                        break;
                    case RequestMsgType.Event:
                        Event eventType = EventHelper.GetEventType(doc);
                        //判断Event类型
                        switch (eventType)
                        {
                            case Event.LOCATION://地理位置
                                requestMessage = new RequestMessageEvent_Location();
                                break;
                            case Event.subscribe://订阅（关注）
                                requestMessage = new RequestMessageEvent_Subscribe();
                                break;
                            case Event.unsubscribe://取消订阅（关注）
                                requestMessage = new RequestMessageEvent_Unsubscribe();
                                break;
                            case Event.CLICK://菜单点击
                                requestMessage = new RequestMessageEvent_Click();
                                break;
                            case Event.VIEW://菜单点击[链接跳转]
                                requestMessage = new RequestMessageEvent_View();
                                break;
                            case Event.scan://二维码扫描
                                requestMessage = new RequestMessageEvent_Scan();
                                break;
                            case Event.TEMPLATESENDJOBFINISH://模板消息发送完成
                                requestMessage = new RequestMessageEvent_TemplateSend();
                                break;
                            case Event.MASSSENDJOBFINISH://群发消息发送完成
                                throw new Exception("群发消息回调：" + doc.ToString());//暂时先抛出异常,后期重新优化完善
                                                                                //break;
                            default://其他意外类型（也可以选择抛出异常）
                                //requestMessage = new RequestMessageEventBase();
                                throw new UnknownRequestMsgTypeException(string.Format("EventType：{0} 在RequestMessageFactory中没有对应的处理程序！", eventType), new ArgumentOutOfRangeException());
                        }
                        break;
                    default:
                        throw new UnknownRequestMsgTypeException(string.Format("MsgType：{0} 在RequestMessageFactory中没有对应的处理程序！", msgType), new ArgumentOutOfRangeException());//为了能够对类型变动最大程度容错（如微信目前还可以对公众账号suscribe等未知类型，但API没有开放），建议在使用的时候catch这个异常
                }
                EntityHelper.FillEntityWithXml(requestMessage, doc);
            }
            catch (ArgumentException ex)
            {
                throw new WeixinException(string.Format("RequestMessage转换出错！可能是MsgType不存在或者EventType不存在！，XML：{0}", doc.ToString()), ex);
            }
            return requestMessage;
        }


        /// <summary>
        /// 获取XDocument转换后的IRequestMessageBase实例。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <returns></returns>
        public static RequestMessageBase GetRequestEntity(string xml)
        {
            return GetRequestEntity(XDocument.Parse(xml));
        }


        /// <summary>
        /// 获取XDocument转换后的IRequestMessageBase实例。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <param name="stream">如Request.InputStream</param>
        /// <returns></returns>
        public static RequestMessageBase GetRequestEntity(Stream stream)
        {
            using (XmlReader xr = XmlReader.Create(stream))
            {
                var doc = XDocument.Load(xr);
                return GetRequestEntity(doc);
            }
        }
    }
}
