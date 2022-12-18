namespace ServiceBus.Events
{
    public class RequestReceivedArgs
    {
        public string Topic { get; set; } = "";
        public string RequestBody { get; set; } = "";
        public string ReplyTopic { get; set; } = "";
        public Guid RequestId { get; set; }
    }
}
