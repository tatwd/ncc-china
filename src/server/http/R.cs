using System.Security.Principal;
using Ncc.China.Http.Message;

namespace Ncc.China.Http
{
    public static class R
    {
        public static MessageStatusCode Ok => MessageStatusCode.Succeeded;
        public static MessageStatusCode Ko => MessageStatusCode.Failed;

        public static BaseResponseMessage Create(int code, string msg = "ok")
        {
            return new FailedResponseMessage
            {
                Code = (MessageStatusCode)code,
                Message = msg
            };
        }

        public static BaseResponseMessage Create<T>(int code, T data, string msg = "ok")
        {
            return new PayloadResponseMessage<T>
            {
                Code = (MessageStatusCode)code,
                Data = data,
                Message = msg
            };
        }

    }
}
