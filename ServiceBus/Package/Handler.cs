namespace ServiceBus.Package
{
    public record Handler
    {
        public string HandlerName { get; init; }
        public Type HandlerType { get; init; }
    }
}
