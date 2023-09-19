using System;
using System.Net;
using Ehr.Core.Base;
using Ehr.Core.Enums;

namespace Ehr.Core.Exceptions
{
    public class EhrException:Exception
    {
        private readonly int _code;

        private readonly string _message;

        private readonly EhrStatusCode _statusCode;

        public EhrException() : base(EhrTips.SYSTEM_ERROR)
        {

        }

        public EhrException(EhrStatusCode code) : base()
        {
            this._statusCode = code;
        }

        public EhrException(int code, string message) : base(message)
        {
            this._code = code;
            this._message = message;
        }

        public EhrException(HttpStatusCode code, string message) : base(message)
        {
            this._code = (int)code;
            this._message = message;
        }

        public int GetCode()
        {
            return _code;
        }

        public EhrStatusCode GetStatusCode()
        {
            return _statusCode;
        }

        public string GetMessage()
        {
            return _message;
        }
    }
}