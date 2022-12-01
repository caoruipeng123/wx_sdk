namespace WxSdk
{
    public partial class StaticUrl
    {
        /// <summary>
        /// 新增客服账号接口地址
        /// </summary>
        public const string URL_AddCustom = "https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}";
        /// <summary>
        /// 修改客服账号接口地址
        /// </summary>
        public const string URL_UpdateCustom = "https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}";
        /// <summary>
        /// 删除客服账号接口地址
        /// </summary>
        public const string URL_DeleteCustom = "https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}";
        /// <summary>
        /// 设置客服头像地址
        /// </summary>
        public const string URL_SetImage = "http://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}";
        /// <summary>
        /// 获取所有客服账号信息
        /// </summary>
        public const string URL_GetAllCustom = "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}";
        /// <summary>
        /// 发送模板消息
        /// </summary>
        //public const string URL_SendTemplateMessage = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
    }
}
