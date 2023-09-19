using System;

namespace Ehr.Core.ExtendMethods
{
    public static class NumExtend
    {
        public static long ToLong(this double d)
        {
            try
            {
                return Convert.ToInt64(d);
            }
            catch
            {
                return 0L;
            }
        }
    }
}