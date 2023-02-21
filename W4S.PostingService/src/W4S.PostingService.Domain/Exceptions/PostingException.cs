namespace W4S.PostingService.Domain.Exceptions
{
    public class PostingException : Exception
    {
        public int ReturnCode { get; set; }

        public PostingException(string message, int returnCode = 400) : base(message) { 
            ReturnCode = returnCode;
        }

        public PostingException(string message, Exception exception, int returnCode = 400) : base(message, exception)
        {
            ReturnCode = returnCode;
        }
    }
}
