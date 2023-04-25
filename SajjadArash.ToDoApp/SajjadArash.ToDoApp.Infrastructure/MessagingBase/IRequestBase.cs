using MediatR;

namespace SajjadArash.ToDoApp.Infrastructure.MessagingBase
{
    public interface IRequestBase : IRequest
    {
    }
    public interface IRequestBase<TEntity> : IRequest<TEntity> where TEntity : IViewModelBase
    {
    }
}
