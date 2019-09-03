using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Common
{
    /// <summary>
    /// MD5加密工具
    /// </summary>
    public class MD5Tool
    {
        /// <summary>
        /// 给一个字符串进行MD5加密
        /// </summary>
        /// <param name="s">待加密字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string s)
        {
            if (s != null)
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(s);
                    return Encrypt(buffer);
                }
                catch { }
            }
            return "";
        }
        public static string Encrypt(byte[] data)
        {
            string result = "";
            if (data != null)
            {
                try
                {
                    HashAlgorithm algorithm = MD5.Create();
                    byte[] hashBytes = algorithm.ComputeHash(data);
                    result = BitConverter.ToString(hashBytes).Replace("-", "");
                }
                catch { }
            }
            return result;
        }
    }
}
