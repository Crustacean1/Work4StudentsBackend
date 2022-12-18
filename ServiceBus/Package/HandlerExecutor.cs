using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ServiceBus.Events;
using System.Text.Json;
using ServiceBus.Attributes;
using ServiceBus.Abstractions;

namespace ServiceBus.Package
{
    public class HandlerExecutor
    {
        private readonly IServiceProvider provider;

        private readonly IServiceBusFactory serviceBusFactory;
        private IBusServer? busServer;
        private IBusClient? busClient;
        private readonly ILogger<HandlerExecutor> logger;
        private readonly Type handlerType;
        private readonly string baseTopic;

        private bool disposed;

        public HandlerExecutor(IServiceProvider provider, ILogger<HandlerExecutor> logger, Type handlerType, IServiceBusFactory serviceBusFactory)
        {
            this.provider = provider;
            this.logger = logger;
            this.handlerType = handlerType;
            this.serviceBusFactory = serviceBusFactory;

            Attribute? handlerAttribute = Attribute
                .GetCustomAttributes(handlerType, typeof(ServiceBusHandlerAttribute))
                .SingleOrDefault();

            baseTopic = handlerAttribute is ServiceBusHandlerAttribute attr
                ? attr.HandlerName
                : throw new InvalidOperationException($"Class {handlerType.Name} isn't marked with attribute [ServiceBusHandlerAttribute]");
        }

        public void Start()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("HandlerExecutor.Start");
            }
            busServer = serviceBusFactory.CreateServer();
            busClient = serviceBusFactory.GetClient();

            busServer.EventReceived += OnEvent;
            busServer.RequestReceived += OnRequest;

            busServer.Start($"{baseTopic}.*");
        }

        public void Dispose()
        {
            if (!disposed)
            {
                busServer?.Dispose();
                disposed = true;
            }
        }

        private object? InvokeHandler(string topic, string body)
        {
            using (var scope = provider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var methods = handler.GetType().GetMethods();

                var methodToCall = methods
                    .SingleOrDefault(m => Attribute
                            .GetCustomAttributes(m, typeof(ServiceBusMethodAttribute))
                                .Any(a => a is ServiceBusMethodAttribute attribute && $"{baseTopic}.{attribute.EndpointName}" == topic));

                if (methodToCall is MethodInfo method && method.GetParameters().SingleOrDefault() is ParameterInfo parameter)
                {
                    dynamic? eventBody = JsonSerializer.Deserialize(body, parameter.ParameterType);

                    if (eventBody is not null)
                    {
                        logger.LogInformation("Executing handler method {Name}", methodToCall.Name);
                        return method.Invoke(handler, new object[] { eventBody });
                    }
                    else
                    {
                        logger.LogWarning("Couldn't deserialize event body for event: {Topic}", topic);
                        return null;
                    }
                }
                else
                {
                    logger.LogWarning("No suitable method found for topic: {Topic}", topic);
                    return null;
                }
            }
        }

        private void OnEvent(object? _, EventReceivedArgs args)
        {
            _ = InvokeHandler(args.Topic, args.EventBody);
        }

        private void OnRequest(object? _, RequestReceivedArgs args)
        {
            var result = InvokeHandler(args.Topic, args.RequestBody);
            var responseBody = JsonSerializer.Serialize(result);
            busClient?.SendResponse(args.ReplyTopic, args.RequestId, responseBody);
        }
    }
}
