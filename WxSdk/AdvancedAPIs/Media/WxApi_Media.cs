using System.Collections.Generic;
using System.IO;
using System.Text;
using WxSdk.Entities;

namespace WxSdk
{
    /// <summary>
    /// 微信公众号素材
    /// </summary>
    public static partial class MPApi
    {
        /// <summary>
        /// 上传临时素材（图片、语音、视频、和缩略图）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">上传文件类型</param>
        /// <param name="file">上传文件物理路径</param>
        /// <returns></returns>
        public static UploadResultJson Upload(string accessToken, UploadMediaFileType type, string file)
        {
            //微信公众号上传媒体文件接口地址
            //var urlFormat = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
            var fileDictionary = new Dictionary<string, string>();
            fileDictionary["media"] = file;
            return ApiHelper.Upload<UploadResultJson>(accessToken, urlFormat, fileDictionary, type.ToString());
        }
        /// <summary>
        /// 上传永久素材（图片、语音、视频、和缩略图）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UploadResultJson UploadLongMedia(string accessToken, UploadMediaFileType type, string file, string title = "", string introduction = "")
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}";
            var fileDictionary = new Dictionary<string, string>();
            fileDictionary["media"] = file;
            if (type == UploadMediaFileType.video)
            {
                fileDictionary["description"] = new SerializerHelper().GetJsonString(new { title = title, introduction = introduction }); //"{\"title\":\"\", \"introduction\":\"永久素材描述\"}";
            }

            return ApiHelper.Upload<UploadResultJson>(accessToken, urlFormat, fileDictionary, type.ToString());
        }
        /// <summary>
        /// 上传永久素材（图文消息）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="news"></param>
        /// <returns></returns>
        public static UploadResultJson UploadLongNews(string accessToken, List<MideaNews> news)
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}";
            return ApiHelper.Post<UploadResultJson>(accessToken, urlFormat, new { articles = news });
        }
        /// <summary>
        /// 上传图文消息内的图片获取URL
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UploadResultJson UploadNewsImg(string accessToken, string file)
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}";
            var fileDictionary = new Dictionary<string, string>();
            fileDictionary["media"] = file;
            return ApiHelper.Upload<UploadResultJson>(accessToken, urlFormat, fileDictionary);
        }
        /// <summary>
        /// 下载临时素材,文件流使用后请及时关闭掉。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="mediaId">媒体文件ID</param>
        /// <param name="stream">下载结果</param>
        public static Stream DownMedia(string accessToken, string mediaId)
        {
            //微信公众号下载媒体文件接口地址
            var urlFormat = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
            MemoryStream stream = new MemoryStream();
            ApiHelper.DownloadGet(urlFormat, stream, accessToken, mediaId);
            return stream;
        }
        /// <summary>
        /// 下载永久素材,文件流使用后请及时关闭掉。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="mediaId"></param>
        public static Stream DownLongMedia(string accessToken, string mediaId)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}";
            var data = new { media_id = mediaId };
            MemoryStream memory = new MemoryStream();
            string jsonString = new SerializerHelper().GetJsonString(data);
            byte[] bs = Encoding.UTF8.GetBytes(jsonString);
            memory.Write(bs, 0, bs.Length);
            Stream mediaStream = RequestUtility.DownLoadPost(string.Format(urlFormat, accessToken), memory);
            return mediaStream;
        }
        /// <summary>
        /// 获取素材列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">素材的类型，图片（image）、视频（video）、语音 （voice）、图文（news）</param>
        /// <param name="offset">从全部素材的该偏移位置开始返回，0表示从第一个素材返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        public static void GetMediaInfo(string accessToken, string type, string offset, string count)
        {

        }
    }
}
