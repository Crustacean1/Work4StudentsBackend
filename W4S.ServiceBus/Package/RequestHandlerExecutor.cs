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

            logger.LogInformation("Received request: {Topic} reply address: {ReplyAddress} id: {Id} ", args.Topic, args.ReplyTopic, args.RequestId);

            try
            {
                dynamic arg = ParseMessageBody(args.RequestBody);

                object? response = await ExecuteMethod(arg);

                if (response is not null)
                {
                    byte[] responseBody = JsonSerializer.SerializeToUtf8Bytes(response);
                    busProducer?.Reply(args.ReplyTopic, responseBody, args.RequestId);
                }
                else
                {
                    logger.LogError("Invalid return type: method handling {Request} should return non-null type", args.Topic);
                }
            }
            catch (Exception e)
            {
                logger.LogError("Error during request execution {Name}: {Error}", args.Topic, e.Message);
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
