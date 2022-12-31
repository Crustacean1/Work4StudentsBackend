namespace ServiceBus.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BusRequestHandlerAttribute : Attribute
    {
        public string Name { get; set; }

        public BusRequestHandlerAttribute(string name)
        {
            Name = name;
        }
    }
}
