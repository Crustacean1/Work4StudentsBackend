namespace PostingService.Console.ServiceBus
{
    public interface IServiceBusReceiver
    {
      public void RegisterEventHandler<T>(T handler);
    }
}
