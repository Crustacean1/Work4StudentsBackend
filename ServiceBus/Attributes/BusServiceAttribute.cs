namespace ServiceBus.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BusServiceAttribute : Attribute
    {
        public string Name { get; }

        public BusServiceAttribute(string name)
        {
            Name = name;
        }
    }
}
