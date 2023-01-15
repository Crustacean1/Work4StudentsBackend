using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using W4S.ServiceBus.Events;
using System.Text.Json;
using System.Text;

namespace W4S.ServiceBus.Package
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

        protected async Task<object?> InvokeHandler(dynamic arg)
        {
            try
            {
                logger.LogInformation("Invokin scope");

                using (var scope = provider.CreateScope())
                {
                    logger.LogInformation("Starting Invokation returning {ReturnType}", methodInfo.ReturnType.Name);

                    var handler = scope.ServiceProvider.GetRequiredService(methodInfo.DeclaringType!);

                    logger.LogInformation("Handler requested");

                    var parameterType = methodInfo.GetParameters()[0].ParameterType;

                    logger.LogInformation("Executing handler method {Name}", methodInfo.Name);

                    var task = (Task)methodInfo.Invoke(handler, new object[] { arg })!;
                    await task.ConfigureAwait(false);
                    return task.GetType().GetProperty("Result").GetValue(task, null);
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
            var paramType = methodInfo.GetParameters().SingleOrDefault()!.ParameterType;
            return JsonSerializer.Deserialize(argBody, paramType) ?? throw new InvalidOperationException("OnRequest: Received invalid formatted JSON event, aborting...");
        }

        protected abstract void OnMessage(object? _, MessageReceivedEventArgs args);

    }
}
