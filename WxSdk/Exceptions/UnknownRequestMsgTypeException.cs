using System;

namespace WxSdk
{
    /// <summary>
    /// 未知请求类型。
    /// </summary>
    public class UnknownRequestMsgTypeException : WeixinException
    {
        public UnknownRequestMsgTypeException(string message)
            : base(message, null)
        {
        }

        public UnknownRequestMsgTypeException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
