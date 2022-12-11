namespace ServiceBus.Package
{
    public class HandlerContainer
    {
        private readonly List<HandlerDefinition> handlers;

        public HandlerContainer()
        {
            handlers = new List<HandlerDefinition>();
        }

        public void AddHandler(HandlerDefinition handler)
        {
            handlers.Add(handler);
        }

        public IEnumerable<HandlerDefinition> Handlers => handlers;
    }
}
