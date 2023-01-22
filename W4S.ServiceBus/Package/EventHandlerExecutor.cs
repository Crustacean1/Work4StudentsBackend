using Microsoft.Extensions.Logging;
using System.Reflection;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Events;

namespace W4S.ServiceBus.Package
{
    public class EventExecutor : ExecutorBase
    {
        private readonly IBusConsumer busConsumer;
        private readonly ILogger<EventExecutor> logger;

        public EventExecutor(IServiceProvider provider, MethodInfo methodInfo, IBusConsumer busConsumer, ILogger<EventExecutor> logger) : base(provider, methodInfo, logger)
        {
            this.busConsumer = busConsumer;
            this.logger = logger;
            if (!methodInfo.ReturnType.Equals(typeof(void)))
            {
                throw new InvalidOperationException($"Event handler should return void {methodInfo.Name}");
            }
        }

        public override void Start()
        {
            busConsumer.MessageReceived += OnMessage;
            busConsumer.Start();
        }

        protected override void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            try
            {
                dynamic arg = ParseMessageBody(args.RequestBody);
                _ = ExecuteMethod(arg);
            }
            catch (Exception e)
            {
                logger.LogError("Error during event execution for message {Message}: {Error}", args.Topic, e.Message);
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
