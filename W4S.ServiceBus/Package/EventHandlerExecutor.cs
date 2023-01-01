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
            logger.LogInformation("Received event {Topic}", args.Topic);

            try
            {
                dynamic arg = ParseMessageBody(args.RequestBody);
                _ = InvokeHandler(arg);
            }
            catch (Exception e)
            {
                logger.LogError("Error OnMessage: {Error}", e.Message);
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
