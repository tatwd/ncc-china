using Ncc.China.Http.Message;

namespace Ncc.China.Http
{
    public static class MessageStatusCodeExtension
    {
        public static BaseResponseMessage Create(this MessageStatusCode messageStatusCode, string msg)
        {
            return new FailedResponseMessage(messageStatusCode, msg);
        }

        public static BaseResponseMessage Create<T>(this MessageStatusCode messageStatusCode, T data, string msg = "ok")
        {
            return new PayloadResponseMessage<T>
            {
                Code = messageStatusCode,
                Data = data,
                Message = msg
            };
        }

    }
}
