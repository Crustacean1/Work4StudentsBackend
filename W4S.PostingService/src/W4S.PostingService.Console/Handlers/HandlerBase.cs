using MediatR;
using W4S.PostingService.Domain.Exceptions;

namespace W4S.PostingService.Console.Handlers
{
    public class HandlerBase
    {
        protected readonly ILogger<HandlerBase> logger;
        protected readonly ISender sender;

        public HandlerBase(ISender sender, ILogger<HandlerBase> logger)
        {
            this.logger = logger;
            this.sender = sender;
        }

        protected async Task<ResponseWrapper<T>> ExecuteHandler<T>(IRequest<T> request, int successCode)
        {
            try
            {
                var result = await sender.Send(request);

                return new ResponseWrapper<T>
                {
                    ResponseCode = successCode,
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
