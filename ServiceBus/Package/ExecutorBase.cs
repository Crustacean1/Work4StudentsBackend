using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ServiceBus.Events;
using System.Text.Json;
using System.Text;

namespace ServiceBus.Package
{
    public abstract class ExecutorBase
    {
        private readonly IServiceProvider provider;

        private readonly ILogger<ExecutorBase> logger;
        private readonly MethodInfo methodInfo;

        public ExecutorBase(IServiceProvider provider, MethodInfo methodInfo, ILogger<ExecutorBase> logger)
        {
            this.provider = provider;
            this.methodInfo = methodInfo;
            this.logger = logger;

            if (methodInfo.GetParameters().Length != 1)
            {
                throw new InvalidOperationException($"Invalid method signature: {methodInfo.Name} must declare one parameter!");
            }
        }

        public abstract void Start();

        protected dynamic? InvokeHandler(dynamic arg)
        {
            try
            {
                using (var scope = provider.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetRequiredService(methodInfo.DeclaringType!);

                    var methods = handler.GetType().GetMethods();

                    var parameterType = methodInfo.GetParameters()[0].ParameterType;

                    logger.LogInformation("Executing handler method {Name}", methodInfo.Name);
                    return methodInfo.Invoke(handler, new object[] { arg });
                }
            }
            catch (Exception e)
            {
                logger.LogError("Error in InvokeHandler: {Error}", e.Message);
                return null;
            }
        }

        protected dynamic ParseMessageBody(ReadOnlySpan<byte> body)
        {
            string argBody = Encoding.UTF8.GetString(body);
            return JsonSerializer.Deserialize(argBody, methodInfo.DeclaringType!) ?? throw new InvalidOperationException("OnRequest: Received invalid formatted JSON event, aborting...");
        }

        protected abstract void OnMessage(object? _, MessageReceivedEventArgs args);

    }
}
