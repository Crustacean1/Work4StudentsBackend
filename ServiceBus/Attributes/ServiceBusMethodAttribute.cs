namespace ServiceBus.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ServiceBusMethodAttribute : Attribute
    {
        public string EndpointName { get; }

        public ServiceBusMethodAttribute(string endpointName)
        {
            EndpointName = endpointName;
        }
    }
}
