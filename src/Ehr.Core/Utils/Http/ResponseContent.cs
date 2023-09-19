using System.Collections.Generic;

namespace Ehr.Core.Utils.Http
{
    public class ResponseContent
    {
        public int Code { get; set; } = 400;

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public string Message { get; set; }

        public byte[] Data { get; set; }

        public string DataString { get => ByteUtil.Byte2String(Data); }
    }
}