using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WxSdk
{
    public class WxApiHelper
    {
        public const string SIGN_TYPE_MD5 = "MD5";
        public const string SIGN_TYPE_HMAC_SHA256 = "HMAC-SHA256";
        public static string ToUrl(SortedDictionary<string, object> m_values)
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value == null)
                {
                    throw new Exception("m_values字典内部含有值为null的字段!");
                }

                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }
        public static string CalcHMACSHA1Hash(string plaintext)
        {
            byte[] baText2BeHashed = Encoding.UTF8.GetBytes(plaintext);
            HMACSHA1 hasher = new HMACSHA1();
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            string result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }
        /// <summary>  
        /// SHA1 加密，返回大写字符串  
        /// </summary>  
        /// <param name="content">需要加密字符串</param>  
        /// <returns>返回40位UTF8 大写</returns>  
        public static string SHA1(string content)
        {
            return SHA1(content, Encoding.UTF8);
        }
        /// <summary>  
        /// SHA1 加密，返回大写字符串  
        /// </summary>  
        /// <param name="content">需要加密字符串</param>  
        /// <param name="encode">指定加密编码</param>  
        /// <returns>返回40位大写字符串</returns>  
        public static string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
    }

}
