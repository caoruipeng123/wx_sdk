using System;
using System.Xml.Linq;
using WxSdk.Entities;

namespace WxSdk
{
    public static class ResponseMessageFactory
    {
        /// <summary>
        /// 获取XDocument转换后的IResponseMessageBase实例（通常在反向读取日志的时候用到）。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <returns></returns>
        public static ResponseMessageBase GetResponseEntity(XDocument doc)
        {
            ResponseMessageBase responseMessage = null;
            ResponseMsgType msgType;
            try
            {
                msgType = MsgTypeHelper.GetResponseMsgType(doc);
                switch (msgType)
                {
                    case ResponseMsgType.Text:
                        responseMessage = new ResponseMessageText();
                        break;
                    case ResponseMsgType.Image:
                        responseMessage = new ResponseMessageImage();
                        break;
                    case ResponseMsgType.Voice:
                        responseMessage = new ResponseMessageVoice();
                        break;
                    case ResponseMsgType.Video:
                        responseMessage = new ResponseMessageVideo();
                        break;
                    case ResponseMsgType.Music:
                        responseMessage = new ResponseMessageMusic();
                        break;
                    case ResponseMsgType.News:
                        responseMessage = new ResponseMessageNews();
                        break;
                    default:
                        throw new UnknownRequestMsgTypeException(string.Format("MsgType：{0} 在ResponseMessageFactory中没有对应的处理程序！", msgType), new ArgumentOutOfRangeException());
                }
                EntityHelper.FillEntityWithXml(responseMessage, doc);
            }
            catch (ArgumentException ex)
            {
                throw new WeixinException(string.Format("ResponseMessage转换出错！可能是MsgType不存在！，XML：{0}", doc.ToString()), ex);
            }
            return responseMessage;
        }


        /// <summary>
        /// 获取XDocument转换后的IRequestMessageBase实例。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <returns></returns>
        public static ResponseMessageBase GetResponseEntity(string xml)
        {
            return GetResponseEntity(XDocument.Parse(xml));
        }
    }
}
