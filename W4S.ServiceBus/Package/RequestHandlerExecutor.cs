using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Events;
using System.Reflection;
using System.Text.Json;
using System.Text;

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


        protected override void OnMessage(object? _, MessageReceivedEventArgs args)
        {
            if (!producerCreated)
            {
                producerCreated = true;
                busProducer.Start();
            }

            logger.LogInformation("Received request {Topic}", args.Topic);

            try
            {
                dynamic arg = ParseMessageBody(args.RequestBody);
                logger.LogInformation("Message body parsed");

                object? response = InvokeHandler(arg);

                if (response is not null)
                {
                    var responseBody = JsonSerializer.SerializeToUtf8Bytes(response);
                    logger.LogInformation("Response: {Response}", Encoding.UTF8.GetString(responseBody));
                    busProducer?.Reply(args.ReplyTopic, responseBody, args.RequestId);
                }
            }
            catch (Exception e)
            {
                logger.LogError("Error in OnMessage: {Error}", e.Message);
            }
            finally
            {
                busConsumer.Acknowledge(args.Tag);
            }
        }
    }
}
