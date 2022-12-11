namespace ServiceBus.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceBusHandlerAttribute : Attribute
    {
        public string HandlerName { get; }

        public ServiceBusHandlerAttribute(string name)
        {
            HandlerName = name;
        }
    }
}
