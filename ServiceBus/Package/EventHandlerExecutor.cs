using Microsoft.Extensions.Logging;
using System.Reflection;
using ServiceBus.Abstractions;
using ServiceBus.Events;

namespace ServiceBus.Package
{
    public class EventExecutor : ExecutorBase
    {
        private readonly IBusConsumer busConsumer;
        private ILogger<EventExecutor> logger;

        public EventExecutor(IServiceProvider provider, MethodInfo methodInfo, IBusConsumer busConsumer, ILogger<EventExecutor> logger) : base(provider, methodInfo, logger)
        {
            this.busConsumer = busConsumer;
            this.logger = logger;
        }

        public override void Start()
        {
            busConsumer.MessageReceived += OnMessage;
            busConsumer.Start();
        }

        protected override void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            logger.LogInformation("Received event {Topic}", args.Topic);

            dynamic arg = ParseMessageBody(args.RequestBody);
            _ = InvokeHandler(arg);
        }
    }
}
