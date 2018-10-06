namespace Ncc.China.Http.Message
{
    public class SucceededResponseMessage : BaseResponseMessage
    {
        public object Data { get; set; }

        public SucceededResponseMessage(object data)
        {
            Code = MessageStatusCode.Succeeded;
            Message = "succeeded";
            Data = data;
        }

        public SucceededResponseMessage(string message, object data)
        {
            Code = MessageStatusCode.Succeeded;
            Message = string.Format("succeeded:{0}", message);
            Data = data;
        }
    }
}
