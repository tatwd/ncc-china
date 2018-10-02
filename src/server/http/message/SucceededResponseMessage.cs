namespace Ncc.China.Http.Message
{
    public class SucceededResponseMessage : BaseResponseMessage
    {
        public object Payload { get; set; }

        public SucceededResponseMessage(object payload)
        {
            Code = MessageStatusCode.Succeeded;
            Message = "succeeded";
            Payload = payload;
        }

        public SucceededResponseMessage(string message, object payload)
        {
            Code = MessageStatusCode.Succeeded;
            Message = string.Format("succeeded:", message);
            Payload = payload;
        }
    }
}
