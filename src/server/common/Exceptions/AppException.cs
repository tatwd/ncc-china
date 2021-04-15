using System;

namespace Ncc.China.Common.Exceptions
{
    public class AppException : ApplicationException
    {
        public int Code { get; }

        public AppException(int code, string msg) : base(msg)
        {
            Code = code;
        }

    }
}
