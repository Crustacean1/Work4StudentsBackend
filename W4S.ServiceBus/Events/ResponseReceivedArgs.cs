namespace W4S.ServiceBus.Events
{
    public class ResponseReceivedArgs
    {
        public string ResponseBody { get; set; } = "";
        public Guid RequestId { get; set; }
    }
}
