namespace WxSdk
{
    /// <summary>
    /// 用户发送消息类型
    /// </summary>
    public enum RequestMsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text,
        /// <summary>
        /// 地理位置消息
        /// </summary>
        Location,
        /// <summary>
        /// 图片消息
        /// </summary>
        Image,
        /// <summary>
        /// 语音消息
        /// </summary>
        Voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        Video,
        /// <summary>
        /// 链接消息
        /// </summary>
        Link,
        /// <summary>
        /// 事件消息
        /// </summary>
        Event,
    }

    /// <summary>
    /// 当RequestMsgType类型为Event时，Event属性的类型
    /// </summary>
    public enum Event
    {
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        LOCATION,
        /// <summary>
        /// 关注事件
        /// </summary>
        subscribe,
        /// <summary>
        /// 取消关注
        /// </summary>
        unsubscribe,
        /// <summary>
        /// 自定义菜单点击事件
        /// </summary>
        CLICK,
        /// <summary>
        /// 扫描带参数二维码事件
        /// </summary>
        scan,
        /// <summary>
        /// 自定义菜单跳转链接事件
        /// </summary>
        VIEW,
        /// <summary>
        /// 模板消息发送结束
        /// </summary>
        TEMPLATESENDJOBFINISH,
        /// <summary>
        /// 群发消息发送结束
        /// </summary>
        MASSSENDJOBFINISH
    }


    /// <summary>
    /// 公众号回复消息类型
    /// </summary>
    public enum ResponseMsgType
    {
        /// <summary>
        /// 回复文本消息
        /// </summary>
        Text,
        /// <summary>
        /// 回复图文消息
        /// </summary>
        News,
        /// <summary>
        /// 回复音乐消息
        /// </summary>
        Music,
        /// <summary>
        /// 回复图片消息
        /// </summary>
        Image,
        /// <summary>
        /// 回复语音消息
        /// </summary>
        Voice,
        /// <summary>
        /// 回复视频消息
        /// </summary>
        Video
    }

    /// <summary>
    /// 菜单按钮类型
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// 点击
        /// </summary>
        click,
        /// <summary>
        /// Url
        /// </summary>
        view,
        /// <summary>
        /// 小程序
        /// </summary>
        miniprogram
    }





    /// <summary>
    /// 上传媒体文件类型
    /// </summary>
    public enum UploadMediaFileType
    {
        /// <summary>
        /// 图片: 128K，支持JPG格式
        /// </summary>
        image,
        /// <summary>
        /// 语音：256K，播放长度不超过60s，支持AMR\MP3格式
        /// </summary>
        voice,
        /// <summary>
        /// 视频：1MB，支持MP4格式
        /// </summary>
        video,
        /// <summary>
        /// thumb：64KB，支持JPG格式
        /// </summary>
        thumb
    }

    /// <summary>
    /// 微信接口返回错误类型
    /// 所有的官方错误类型定义参见：
    /// http://mp.weixin.qq.com/wiki/index.php?title=全局返回码说明
    /// </summary>
    public enum ReturnCode
    {
        系统繁忙 = -1,
        请求成功 = 0,
        验证失败 = 40001,
        不合法的凭证类型 = 40002,
        不合法的OpenID = 40003,
        不合法的媒体文件类型 = 40004,
        不合法的文件类型 = 40005,
        不合法的文件大小 = 40006,
        不合法的媒体文件id = 40007,
        不合法的消息类型 = 40008,
        不合法的图片文件大小 = 40009,
        不合法的语音文件大小 = 40010,
        不合法的视频文件大小 = 40011,
        不合法的缩略图文件大小 = 40012,
        不合法的APPID = 40013,
        //不合法的access_token      =             40014,
        不合法的access_token = 40014,
        不合法的菜单类型 = 40015,
        //不合法的按钮个数             =          40016,
        //不合法的按钮个数              =         40017,
        不合法的按钮个数1 = 40016,
        不合法的按钮个数2 = 40017,
        不合法的按钮名字长度 = 40018,
        不合法的按钮KEY长度 = 40019,
        不合法的按钮URL长度 = 40020,
        不合法的菜单版本号 = 40021,
        不合法的子菜单级数 = 40022,
        不合法的子菜单按钮个数 = 40023,
        不合法的子菜单按钮类型 = 40024,
        不合法的子菜单按钮名字长度 = 40025,
        不合法的子菜单按钮KEY长度 = 40026,
        不合法的子菜单按钮URL长度 = 40027,
        不合法的自定义菜单使用用户 = 40028,
        缺少access_token参数 = 41001,
        缺少appid参数 = 41002,
        缺少refresh_token参数 = 41003,
        缺少secret参数 = 41004,
        缺少多媒体文件数据 = 41005,
        缺少media_id参数 = 41006,
        缺少子菜单数据 = 41007,
        access_token超时 = 42001,
        需要GET请求 = 43001,
        需要POST请求 = 43002,
        需要HTTPS请求 = 43003,
        多媒体文件为空 = 44001,
        POST的数据包为空 = 44002,
        图文消息内容为空 = 44003,
        多媒体文件大小超过限制 = 45001,
        消息内容超过限制 = 45002,
        标题字段超过限制 = 45003,
        描述字段超过限制 = 45004,
        链接字段超过限制 = 45005,
        图片链接字段超过限制 = 45006,
        语音播放时间超过限制 = 45007,
        图文消息超过限制 = 45008,
        接口调用超过限制 = 45009,
        创建菜单个数超过限制 = 45010,
        不存在媒体数据 = 46001,
        不存在的菜单版本 = 46002,
        不存在的菜单数据 = 46003,
        解析JSON_XML内容错误 = 47001,
        api功能未授权 = 48001,
        用户未授权该api = 50001
    }

    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 中文简体
        /// </summary>
        zh_CN,
        /// <summary>
        /// 中文繁体
        /// </summary>
        zh_TW,
        /// <summary>
        /// 英文
        /// </summary>
        en
    }
}
