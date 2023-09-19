using System;
using System.Collections.Generic;
using System.Linq;
using Ehr.Core.Utils;

namespace Ehr.Core.Data.Models
{
    public class EhrResponse
    {
        public int Code { get; set; } = 200;

        public string Message { get; set; }

        public long _t { get; set; } = TimeUtil.GetTime(); //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }

    public class EhrResponse<T> : EhrResponse
    {
        public object Data { get; private set; }

        public int Count { get; set; } = 1;

        public void SetData(T t)
        {
            this.Data = t;
            Count = 1;
        }

        public void SetData(IEnumerable<T> t)
        {
            this.Data = t;
            Count = t == null ? 0 : t.ToArray().Length;
        }
    }


}