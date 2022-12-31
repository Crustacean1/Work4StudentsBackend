using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;
using ServiceBus.Events;
using System.Reflection;
using System.Text.Json;

namespace ServiceBus.Package
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
        }

        public override void Start()
        {
            busConsumer.MessageReceived += OnMessage;

            busConsumer.Start();
        }


        protected override void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            if (!producerCreated)
            {
                producerCreated = true;
                busProducer.Start();
            }

            logger.LogInformation("Received request {Topic}", args.Topic);

            dynamic arg = ParseMessageBody(args.RequestBody);
            object? response = InvokeHandler(arg);

            if (response is not null)
            {
                var responseBody = JsonSerializer.SerializeToUtf8Bytes(response);
                busProducer?.Reply(args.Topic, responseBody, args.RequestId);
            }
        }
    }
}
