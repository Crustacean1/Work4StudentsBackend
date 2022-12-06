namespace ServiceBus.Package
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ServiceBusEventHandlerAttribute : Attribute
    {
        public string EventName { get; }

        public ServiceBusEventHandlerAttribute(string eventName)
        {
            EventName = eventName;
        }
    }
}
