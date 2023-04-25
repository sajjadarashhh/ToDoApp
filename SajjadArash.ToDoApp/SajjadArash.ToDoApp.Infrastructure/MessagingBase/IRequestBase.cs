using MediatR;

namespace SajjadArash.ToDoApp.Infrastructure.MessagingBase
{
    /// <summary>
    /// ساختار درخواست های پروژه
    /// </summary>
    public interface IRequestBase : IRequest<IResponseBase>
    {
    }
    /// <summary>
    /// <inheritdoc cref="IRequestBase"/>
    /// </summary>
    /// <typeparam name="TEntity">نوع ورودی کاربر</typeparam>
    public interface IRequestBase<TEntity> : IRequestBase where TEntity : IViewModelBase
    {
        public TEntity Entity { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IRequestBase"/>
    /// </summary>
    /// <typeparam name="TEntity">ورودی کاربر</typeparam>
    /// <typeparam name="TResponse">خروجی</typeparam>
    public interface IRequestBase<TEntity, TResponse> : IRequestBase<TEntity> where TEntity : IViewModelBase where TResponse : IViewModelBase
    {

    }
    /// <summary>
    /// <inheritdoc cref="IRequestBase"/>
    /// </summary>
    public interface IRequestPagingBase : IRequestBase
    {
        public int Size { get; set; }
        public int Index { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IRequestBase"/>
    /// </summary>
    /// <typeparam name="TEntity"><inheritdoc cref="IRequestBase{TEntity}"/></typeparam>
    public interface IRequestPagingBase<TEntity> : IRequestPagingBase, IRequestBase<TEntity> where TEntity : IViewModelBase
    {
    }
    /// <summary>
    /// <inheritdoc cref="IRequestBase"/>
    /// </summary>
    /// <typeparam name="TEntity">ورودی کاربر</typeparam>
    /// <typeparam name="TResponse">خروجی کاربر</typeparam>
    public interface IRequestPagingBase<TEntity, TResponse> : IRequestPagingBase, IRequestBase<TEntity, TResponse> where TEntity : IViewModelBase where TResponse : IViewModelBase
    {
    }
}
