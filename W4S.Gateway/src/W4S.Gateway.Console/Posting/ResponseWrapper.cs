namespace W4S.Gateway.Console.Posting
{
    public class ResponseWrapper<T>
    {
        public int ResponseCode { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public T Response { get; set; }
    }
}
