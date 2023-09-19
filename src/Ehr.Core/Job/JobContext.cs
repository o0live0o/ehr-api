using System;

namespace Ehr.Core.Job
{
    public class JobContext
    {
        public Type ClassType { get; set; }

        public string MethodName { get; set; }

        public object[] Args { get; set; }

        public string Cron { get; set; }

        public string JobName { get; set; }

    }
}