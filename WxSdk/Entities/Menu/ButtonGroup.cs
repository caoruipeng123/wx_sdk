using System.Collections.Generic;

namespace WxSdk.Entities
{
    /// <summary>
    /// 整个按钮设置（可以直接用ButtonGroup实例返回JSON对象）
    /// </summary>
    public class ButtonGroup
    {
        /// <summary>
        /// 按钮数组，按钮个数应为1~3个
        /// </summary>
        public List<BaseButton> button { get; set; }

        public ButtonGroup()
        {
            button = new List<BaseButton>();
        }
    }
}
