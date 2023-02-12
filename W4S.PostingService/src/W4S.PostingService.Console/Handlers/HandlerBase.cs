using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Console.Handlers
{
    public class HandlerBase
    {
        protected readonly ILogger<HandlerBase> logger;

        public HandlerBase(ILogger<HandlerBase> logger)
        {
            this.logger = logger;
        }

        protected async Task<ResponseWrapper<T>> ExecuteHandler<T>(Func<Task<(T result, int responseCode)>> handlerAction)
        {
            try
            {
                var (result, responseCode) = await handlerAction();

                return new ResponseWrapper<T>
                {
                    ResponseCode = responseCode,
                    Response = result
                };
            }
            catch (PostingException ex)
            {
                logger.LogError("Error occured: {Error}\n{InnerError}\n{StackTrace}", ex.Message, ex.InnerException?.Message ?? "<No inner exception>", ex.StackTrace);
                return new ResponseWrapper<T>
                {
                    Messages = new List<string> { ex.Message
},
                    ResponseCode = ex.ReturnCode
                };
            }
            catch (Exception ex)
            {
                logger.LogError("Unexpected error occured: {Error}\n{InnerError}\n{StackTrace}", ex.Message, ex.InnerException?.Message ?? "<No inner exception>", ex.StackTrace);
                return new ResponseWrapper<T>
                {
                    Messages = new List<string> { ex.Message },
                    ResponseCode = 500
                };
            }
        }
    }
}
