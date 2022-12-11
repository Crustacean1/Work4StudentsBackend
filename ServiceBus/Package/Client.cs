using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ServiceBus.Abstractions;
using ServiceBus.Events;

namespace ServiceBus.Package
{
    public class Client : IClient
    {
        private readonly IBusClient busClient;
        private ConcurrentDictionary<Guid, PendingResponse> pendingResponses;
        private ILogger<Client> logger;

        public Client(IServiceBusFactory busFactory, ILogger<Client> logger)
        {
            busClient = busFactory.GetClient();
            busClient.ResponseReceived += OnResponse;
            pendingResponses = new ConcurrentDictionary<Guid, PendingResponse>();
            this.logger = logger;
        }

        public void SendEvent<TEvent>(string topic, TEvent busEvent) where TEvent : class
        {
            var eventBody = JsonSerializer.Serialize(busEvent);
            busClient.SendEvent(topic, eventBody);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request) where TResponse : class where TRequest : class
        {
            return await SendRequest<TResponse, TRequest>(topic, request, CancellationToken.None);
        }

        public async Task<TResponse> SendRequest<TResponse, TRequest>(string topic, TRequest request, CancellationToken cancellationToken) where TResponse : class where TRequest : class
        {
            string requestBody = JsonSerializer.Serialize(request);

            var requestId = Guid.NewGuid();

            var pendingResponse = new PendingResponse();

            if (!pendingResponses.TryAdd(requestId, pendingResponse))
            {
                throw new InvalidDataException("This shouldn't have ever happened");
            }

            busClient.SendRequest(topic, requestId, requestBody);

            string responseBody = await pendingResponse.Get(cancellationToken);
            dynamic? response = JsonSerializer.Deserialize(responseBody, typeof(TResponse));
            return response is null ? throw new InvalidOperationException("Response is empty") : (TResponse)response;
        }

        private void OnResponse(object? _, ResponseReceivedArgs args)
        {
            if (pendingResponses.TryGetValue(args.RequestId, out PendingResponse? response))
            {
                response.Set(args.ResponseBody);
            }
        }
    }
}
