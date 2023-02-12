namespace W4S.Gateway.Console.Posting
{
    public class Result<T>
    {
        public List<string> Messages { get; set; }

        public T Response{get;set;}
    }
}
