using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WxSdk
{
    public class Util
    {
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="aesKey"></param>
        /// <param name="ivs"></param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string aesKey, string ivs)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(text);
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.KeySize = 128;
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                rijndaelCipher.Key = Convert.FromBase64String(aesKey);
                rijndaelCipher.IV = Convert.FromBase64String(ivs);
                ICryptoTransform transform = rijndaelCipher.CreateDecryptor(rijndaelCipher.Key, rijndaelCipher.IV);

                byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                string result = Encoding.UTF8.GetString(plainText);
                return result;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
