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

        protected async Task<MessageWrapper<object?>> ExecuteMethod(dynamic arg)
        {
            MessageWrapper<object?> wrapper = new();

            try
            {
                using (var scope = provider.CreateScope())
                {
                    logger.LogInformation("Executing handler method: {Name} with return type: {Type}", methodInfo.Name, methodInfo.ReturnType.Name);
                    var handler = scope.ServiceProvider.GetRequiredService(methodInfo.DeclaringType!);
                    wrapper.Message = await InvokeHandler(handler, arg);
                    logger.LogInformation("Method executed");
                }
            }
            catch (Exception e)
            {
                wrapper.Error = $"{e.Message}\nInner Exception:\n{e.InnerException?.Message ?? "<No internal exception>"}\nStackTrace:\n{e.StackTrace}";
                logger.LogInformation("Failed to execute method: {Error}", wrapper.Error ?? "No error?");
            }

            return wrapper;
        }

        private async Task<object?> InvokeHandler(object handler, dynamic arg)
        {
            object? result = methodInfo.Invoke(handler, new object[] { arg });

            if (result is Task task)
            {
                await task;
                return task.GetType().GetProperty("Result")!.GetValue(task, null);
            }
            else
            {
                return result;
            }
        }

        protected (dynamic, string) ParseMessageBody(ReadOnlySpan<byte> body)
        {
            string argBody = Encoding.UTF8.GetString(body);
            var paramType = methodInfo.GetParameters().SingleOrDefault()!.ParameterType;
            return (JsonSerializer.Deserialize(argBody, paramType) ?? throw new InvalidOperationException("OnRequest: Received invalid formatted JSON event, aborting..."), argBody);
        }

        protected abstract void OnMessage(object? _, MessageReceivedEventArgs args);

    }
}
