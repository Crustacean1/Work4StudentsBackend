using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Events;
using System.Reflection;
using System.Text.Json;

namespace W4S.ServiceBus.Package
{
    public class RequestExecutor : ExecutorBase
    {
        private readonly ILogger<RequestExecutor> logger;

        private readonly IBusProducer busProducer;
        private readonly IBusConsumer busConsumer;

        private bool producerCreated;

        public RequestExecutor(IServiceProvider provider,
                               MethodInfo methodInfo,
                               IBusConsumer busConsumer,
                               IBusProducer busProducer,
                               ILogger<RequestExecutor> logger) : base(provider, methodInfo, logger)
        {
            this.busConsumer = busConsumer;
            this.busProducer = busProducer;
            this.logger = logger;

            if (methodInfo.ReturnType.Equals(typeof(void)))
            {
                throw new InvalidOperationException($"Request handler must return some value: {methodInfo.Name}");
            }
        }

        public override void Start()
        {
            busConsumer.MessageReceived += OnMessage;

            busConsumer.Start();
        }


        protected override async void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            if (!producerCreated)
            {
                producerCreated = true;
                busProducer.Start();
            }

            try
            {
                var (param, paramBody) = ParseMessageBody(args.RequestBody);

                var truncated = paramBody?.Length > 1024;
                var redactedMessage = paramBody?.Substring(0, truncated ? 1024 : paramBody.Length) ?? "<NULL>";

                logger.LogInformation("Received request: {Request} {IsTrimmed} at address: {Topic} with reply address: {ReplyAddress} id: {Id}", redactedMessage, truncated ? "(truncated)" : "", args.Topic, args.ReplyTopic, args.RequestId);

                MessageWrapper<object?> response = await ExecuteMethod(param);
                byte[] responseBody = JsonSerializer.SerializeToUtf8Bytes(response);
                busProducer?.Reply(args.ReplyTopic, responseBody, args.RequestId);
            }
            catch (Exception e)
            {
                logger.LogError("Error while sending response to request {Name}: {Error}\nInternal Exception:\n{InternalException}", args.Topic, e.Message, e.InnerException?.Message ?? "<No Internal Exception>");
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
