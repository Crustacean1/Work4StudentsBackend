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
            Start();
            byte[] eventBody = JsonSerializer.SerializeToUtf8Bytes(busEvent);
            logger.LogInformation("Sending event");
            busProducer.Publish(topic, eventBody);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request) where TResponse : class where TRequest : class
        {
            return await SendRequest<TResponse, TRequest>(topic, request, CancellationToken.None);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request, CancellationToken cancellationToken) where TResponse : class where TRequest : class
        {
            Start();

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

            var truncated = responseBody?.Length > 1024;
            var redactedMessage = responseBody?.Substring(0, truncated ? 1024 : responseBody.Length) ?? "<NULL>";

            logger.LogInformation("Received response: {Response} {IsTruncated}", redactedMessage, truncated ? "(truncated)" : "");

            dynamic? rawResponse = JsonSerializer.Deserialize(responseBody, typeof(MessageWrapper<TResponse>));

            if (rawResponse is MessageWrapper<TResponse> response)
            {
                if (string.IsNullOrEmpty(response.Error))
                {
                    return response.Message;
                }
                throw new InvalidOperationException(response.Error);
            }
            throw new InvalidOperationException("Response is empty");
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

        private void Start()
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
