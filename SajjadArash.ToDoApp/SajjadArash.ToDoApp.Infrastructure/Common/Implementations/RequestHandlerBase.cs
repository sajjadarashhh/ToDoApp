using FluentValidation;
using MediatR;
using SajjadArash.ToDoApp.Infrastructure.MessagingBase;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Implementation
{
    public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest, IResponseBase> where TRequest : IRequestBase
    {

        public abstract Task<IResponseBase> Handle(TRequest request, CancellationToken cancellationToken);
    }
    public abstract class RequestHandlerBase<TRequest, TEntity> : AbstractValidator<TEntity>, IRequestHandler<TRequest, IResponseBase> where TRequest : IRequestBase<TEntity> where TEntity : IViewModelBase
    {
        protected RequestHandlerBase()
        {
            ImplementValidations();
        }

        protected abstract void ImplementValidations();
        public abstract Task<IResponseBase> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
