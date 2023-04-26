using FluentValidation;
using MediatR;
using SajjadArash.ToDoApp.Infrastructure.Common.Exceptions;
using SajjadArash.ToDoApp.Infrastructure.Enums;
using SajjadArash.ToDoApp.Infrastructure.Extensions;
using SajjadArash.ToDoApp.Infrastructure.MessagingBase;
using Serilog;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Behaviours
{
    /// <summary>
    /// مدیریت خطاهای درون سرویس
    /// </summary>
    public class ExceptionHandlerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequestBase where TResponse : IResponseBase
    {

        private readonly ILogger _logger;

        public ExceptionHandlerBehaviour(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ValidationException ex)
            {
                return (TResponse)request.Exception(ApplicationCodes.InputInvalid, $"ورودی های زیر اشتباه است: {string.Join("\r\n",ex.Errors.Select(a => $"{a.PropertyName}: {a.ErrorMessage}"))}");
            }
            catch (ToDoAppExceptionBase ex)
            {
                return (TResponse)request.Exception(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error an occured. input : {request} ,request name: {requestName}", request, request.GetType().Name);
                return (TResponse)request.Exception(ApplicationCodes.Exception);
            }
        }
    }
}
