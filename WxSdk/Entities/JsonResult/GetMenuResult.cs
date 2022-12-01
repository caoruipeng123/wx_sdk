namespace WxSdk.Entities
{
    /// <summary>
    /// GetMenu的返回结果实体
    /// </summary>
    public class GetMenuResult
    {
        public ButtonGroup menu { get; set; }

        public GetMenuResult()
        {
            menu = new ButtonGroup();
        }
    }
}
