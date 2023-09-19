using System;
using Ehr.Core.ExtendMethods;

namespace Ehr.Core.Utils
{
    public abstract class TimeUtil
    {
        /// <summary>
        /// 过期时间(毫秒)
        /// </summary>
        /// <param name="expireTime">过期时间(毫秒)</param>
        /// <returns></returns>
        public static long GetTime(long expireTime = 0)
        {
            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            return timeSpan.TotalMilliseconds.ToLong() + expireTime;
        }
    }
}