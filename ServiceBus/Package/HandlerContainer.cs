namespace ServiceBus.Package
{
    public class HandlerContainer
    {
        private readonly List<Handler> handlers;

        public HandlerContainer()
        {
            handlers = new List<Handler>();
        }

        public void AddHandler(Handler handler)
        {
            handlers.Add(handler);
        }

        public IEnumerable<Handler> Handlers => handlers;
    }
}
