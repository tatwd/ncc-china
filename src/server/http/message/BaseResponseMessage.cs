namespace Ncc.China.Http.Message
{
    public abstract class BaseResponseMessage
    {
        public MessageStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}
