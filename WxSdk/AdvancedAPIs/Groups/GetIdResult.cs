namespace WxSdk.Entities
{
    /// <summary>
    /// 查询单个用户所在分组返回结果
    /// </summary>
    public class GetGroupIdResult : WxJsonResult
    {
        /// <summary>
        /// 用户所在的分组ID，由微信分配
        /// </summary>
        public int groupid { get; set; }
    }
}
