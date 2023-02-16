namespace W4S.ServiceBus.Package
{
    public class MessageWrapper<T>
    {
        public string Error { get; set; }

        public T Message { get; set; }
    }
}
