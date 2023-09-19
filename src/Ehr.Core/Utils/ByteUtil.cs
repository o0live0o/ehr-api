using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ehr.Core.Utils
{
    public abstract class ByteUtil
    {
        /// <summary>
        /// 把byte数组转成字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static async Task<string> Byte2StringAsync(byte[] bytes, string encode = "utf-8")
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            Stream stream = new MemoryStream(bytes);
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(encode));
            return await sr.ReadToEndAsync();
        }

        public static string Byte2String(byte[] bytes, string encode = "utf-8")
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            Stream stream = new MemoryStream(bytes);
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(encode));
            return sr.ReadToEnd();
        }
    }
}