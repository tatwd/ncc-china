namespace Ncc.China.Http.Message
{
    public class PayloadResponseMessage<T> : BaseResponseMessage
    {
        public T Data { get; set; }
    }
}
