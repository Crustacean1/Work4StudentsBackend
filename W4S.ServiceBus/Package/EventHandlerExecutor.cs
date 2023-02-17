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
        }

        public override void Start()
        {
            busConsumer.MessageReceived += OnMessage;
            busConsumer.Start();
        }

        protected override async void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            try
            {
                var (param, paramBody) = ParseMessageBody(args.RequestBody);

                var truncated = paramBody?.Length > 1024;
                var redactedMessage = paramBody?.Substring(0, truncated ? 1024 : paramBody.Length) ?? "<NULL>";
                logger.LogInformation("Received event: {Request} {IsTrimmed} at address: {Topic} with id: {Id}", redactedMessage, truncated ? "(truncated)" : "", args?.Topic ?? "No topic", "No request id");

                _ = await ExecuteMethod(param);
            }
            catch (Exception e)
            {
                logger.LogError("Error during event execution for message {Message}: {Error} \n{InnerError}", args.Topic, e.Message, e.InnerException?.Message ?? "No innards");
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
