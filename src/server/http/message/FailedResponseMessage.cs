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
            Message = string.Format("failed:{0}", message);
        }

        public FailedResponseMessage(MessageStatusCode code, string message)
        {
            Code = code;
            Message = string.Format("failed:{0}", message);
        }
    }
}
