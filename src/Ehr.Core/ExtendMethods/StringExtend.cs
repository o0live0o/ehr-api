using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ehr.Core.ExtendMethods
{
    public static class StringExtend
    {
        public static int ToInt(this string s)
        {
            if (int.TryParse(s, out int val))
                return val;
            return 0;
        }

        public static double ToDouble(this string s)
        {
            if (double.TryParse(s, out double val))
                return val;
            return 0;
        }

        public static bool RegexIsMatch(this string s, string rule)
        {
            Regex regex = new Regex(rule);
            var match = regex.Match(s);
            return match.Success;
        }

        public static string Match(this string s,string rule,int poisition = 0)
        {
            Regex regex = new Regex(rule);
            var match = regex.Match(s);
            if(match.Success)
            {
                return match.Groups[poisition].Value;
            }
            return "";
        }

        public static List<string[]> SplitArr(this string[] arr, int len)
        {
            int count = arr.Length % len == 0 ? arr.Length / len : arr.Length / len + 1;
            List<string[]> subAryList = new List<string[]>();
            for (int i = 0; i < count; i++)
            {
                int index = i * len;
                string[] subary = arr.Skip(index).Take(len).ToArray();
                subAryList.Add(subary);
            }
            return subAryList;
        }
    }
}