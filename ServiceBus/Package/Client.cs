using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;
using ServiceBus.Events;

namespace ServiceBus.Package
{
    public class Client : IClient
    {
        private readonly IBusProducer busProducer;
        private readonly IBusConsumer busConsumer;
        private readonly ConcurrentDictionary<Guid, PendingResponse> pendingResponses = new();

        private readonly string replyQueue;

        private ILogger<Client> logger;

        private bool startedListening;

        public Client(IServiceBusFactory busFactory, ILogger<Client> logger)
        {
            replyQueue = $"{busFactory.ServiceName}.responses";
            busConsumer = busFactory.CreateRequestConsumer(replyQueue);
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
            if (!startedListening)
            {
                startedListening = true;
                busConsumer.MessageReceived += OnResponse;
                busConsumer.Start();
            }

            var requestBody = JsonSerializer.SerializeToUtf8Bytes(request);

            var pendingResponse = new PendingResponse();

            var requestId = Guid.NewGuid();

            busProducer.Send(topic, replyQueue, requestBody, requestId);

            if (!pendingResponses.TryAdd(requestId, pendingResponse))
            {
                throw new InvalidDataException("This shouldn't have ever happened");
            }

            string responseBody = await pendingResponse.Get(cancellationToken);
            dynamic? response = JsonSerializer.Deserialize(responseBody, typeof(TResponse));
            return response is null ? throw new InvalidOperationException("Response is empty") : (TResponse)response;
        }

        private void OnResponse(object? _, MessageReceivedEventArgs args)
        {
            if (pendingResponses.TryGetValue(args.RequestId, out PendingResponse? response))
            {
                response.Set(args.RequestBody);
            }
        }
    }
}
