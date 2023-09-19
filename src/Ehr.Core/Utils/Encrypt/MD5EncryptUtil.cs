using System.Security.Cryptography;
using System.Text;

namespace Ehr.Core.Utils.Encrypt
{
    public abstract class MD5EncryptUtil
    {
        public static string Md5Encrypt(string val)
        {
            string ret = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(val));
            for (int i = 0; i < s.Length; i++)
            {
                ret = ret + s[i].ToString("X2");
            }
            return ret;
        }
    }
}