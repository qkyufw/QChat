using System.Security.Cryptography;
using System.Text;

namespace QChat.common
{
    internal class md5
    {
        // 该程序用于md5加密，传入一个string，返回一个加密后的string
        internal static string GetMd5Hash(string md5Hash)
        {
            using (var md5 = MD5.Create())
            {
                // 将输入字符串转换为字节数组，并计算哈希值
                byte[] inputBytes = Encoding.UTF8.GetBytes(md5Hash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // 将哈希值转换为16进制字符串
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
