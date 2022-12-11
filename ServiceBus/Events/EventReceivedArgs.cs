namespace ServiceBus.Events
{
    public class EventReceivedArgs
    {
        public string Topic { get; set; } = "";
        public string EventBody { get; set; } = "";
    }
}
