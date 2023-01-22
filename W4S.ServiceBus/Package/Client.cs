using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using W4S.ServiceBus.Abstractions;
using W4S.ServiceBus.Events;

namespace W4S.ServiceBus.Package
{
    public class Client : IClient
    {
        private const int DEFAULT_TIMEOUT = 5;
        private readonly IBusProducer busProducer;
        private readonly IBusConsumer busConsumer;
        private readonly ConcurrentDictionary<Guid, PendingResponse> pendingResponses = new();

        private readonly string replyQueue;

        private ILogger<Client> logger;

        private bool startedReceiving;

        public Client(IServiceBusFactory busFactory, ILogger<Client> logger)
        {
            replyQueue = $"{busFactory.ServiceName}.responses";
            busConsumer = busFactory.CreateUnicastConsumer(replyQueue);
            busProducer = busFactory.CreateProducer();
            this.logger = logger;
        }

        public void SendEvent<TEvent>(string topic, TEvent busEvent) where TEvent : class
        {
            var eventBody = JsonSerializer.SerializeToUtf8Bytes(busEvent);
            busProducer.Publish(topic, eventBody);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request) where TResponse : class where TRequest : class
        {
            return await SendRequest<TResponse, TRequest>(topic, request, CancellationToken.None);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request, CancellationToken cancellationToken) where TResponse : class where TRequest : class
        {
            StartReceiving();

            var requestBody = JsonSerializer.SerializeToUtf8Bytes(request);

            var pendingResponse = new PendingResponse(DEFAULT_TIMEOUT);

            var requestId = Guid.NewGuid();

            busProducer.Send(topic, replyQueue, requestBody, requestId);

            if (!pendingResponses.TryAdd(requestId, pendingResponse))
            {
                throw new InvalidDataException("Error while subscribing for servicebus response");
            }

            string? responseBody = await pendingResponse.Get(cancellationToken);

            if (responseBody is null)
            {
                throw new TimeoutException($"Timeout while waiting for: {topic}");
            }

            logger.LogInformation("Received response: {Response}", responseBody);

            dynamic? response = JsonSerializer.Deserialize(responseBody, typeof(TResponse));

            return response is null ? throw new InvalidOperationException("Response is empty") : (TResponse)response;
        }

        private void OnResponse(object? _, MessageReceivedEventArgs args)
        {
            busConsumer.Acknowledge(args.Tag);

            if (pendingResponses.TryGetValue(args.RequestId, out PendingResponse? response))
            {
                response.Set(args.RequestBody);
            }
            else
            {
                logger.LogInformation("Received unwanted response {Content}", Encoding.UTF8.GetString(args.RequestBody));
            }
        }

        private void StartReceiving()
        {
            if (!startedReceiving)
            {
                startedReceiving = true;
                busConsumer.MessageReceived += OnResponse;
                busConsumer.Start();
                busProducer.Start();
            }
        }
    }
}
