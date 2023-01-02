namespace W4S.ServiceBus.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BusEventHandlerAttribute : Attribute
    {
        public string Name { get; }

        public BusEventHandlerAttribute(string name)
        {
            Name = name;
        }
    }
}
