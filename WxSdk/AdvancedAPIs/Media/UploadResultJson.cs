

namespace WxSdk.Entities
{
    /// <summary>
    /// 上传媒体文件返回结果
    /// </summary>
    public class UploadResultJson : WxJsonResult
    {
        public UploadMediaFileType type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
        public string url { get; set; }
    }
}
