namespace WxSdk.Entities
{
    /// <summary>
    /// 需要预先上传多媒体文件到微信服务器，只支持认证服务号。
    /// </summary>
    public class ResponseMessageVideo : ResponseMessageBase
    {
        public ResponseMessageVideo()
        {
            Video = new Video();
        }
        new public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Video; }
        }
        public Video Video { get; set; }
    }
}
