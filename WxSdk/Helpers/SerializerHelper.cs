using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WxSdk
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// 将数据实体序列化为Json字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetJsonString(object data)
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            var jsonString = JsonConvert.SerializeObject(data);
            //var jsonString = js.Serialize(data);

            //解码Unicode，也可以通过设置App.Config（Web.Config）设置来做
            MatchEvaluator evaluator = new MatchEvaluator(DecodeUnicode);
            var json = Regex.Replace(jsonString, @"\\u[0123456789abcdef]{4}", evaluator);//或：[\\u007f-\\uffff]，\对应为\u000a，但一般情况下会保持\
            return json;
        }
        /// <summary>
        /// unicode解码
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string DecodeUnicode(Match match)
        {
            if (!match.Success)
            {
                return null;
            }
            char outStr = (char)int.Parse(match.Value.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            return new string(outStr, 1);
        }
    }
}
