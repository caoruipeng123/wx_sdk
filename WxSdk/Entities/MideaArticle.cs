namespace WxSdk.Entities
{
    /// <summary>
    /// 图文素材
    /// </summary>
    public class MideaNews
    {
        /// <summary>
        /// 标题[必选]
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图文消息的封面图片素材id（必须是永久mediaID）[必选]
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空。如果本字段为没有填写，则默认抓取正文前64个字。
        /// </summary>
        public string digest { get; set; }
        /// <summary>
        /// 是否显示封面，0为false，即不显示，1为true，即显示[必选]
        /// </summary>
        public int show_cover_pic { get; set; }
        /// <summary>
        /// 文章内容[必选]
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 图文消息的原文地址，即点击“阅读原文”后的URL[必选]
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 是否打开评论，0不打开，1打开
        /// </summary>
        public int need_open_comment { get; set; }
        /// <summary>
        /// 是否粉丝才可评论，0所有人可评论，1粉丝才可评论
        /// </summary>
        public int only_fans_can_comment { get; set; }
    }
}
