namespace Ncc.China.Http.Message
{
    public class FailedResponseMessage : BaseResponseMessage
    {
        public FailedResponseMessage()
        {
            Code = MessageStatusCode.Failed;
            Message = "failed";
        }

        public FailedResponseMessage(string message)
        {
            Code = MessageStatusCode.Failed;
            Message = $"failed:{message}";
        }

        public FailedResponseMessage(MessageStatusCode code, string message)
        {
            Code = code;
            Message = $"failed:{message}";
        }
    }
}
