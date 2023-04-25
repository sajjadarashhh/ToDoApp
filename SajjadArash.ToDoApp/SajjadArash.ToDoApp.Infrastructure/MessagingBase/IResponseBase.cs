using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.MessagingBase
{
    /// <summary>
    /// ساختار کلی خروجی های پروژه
    /// </summary>
    public interface IResponseBase
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }
        ApplicationCodes Code { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponseBase"/>
    /// </summary>
    /// <typeparam name="TEntity">خروجی</typeparam>
    public interface IResponseBase<TEntity> : IResponseBase
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponseBase"/>
    /// </summary>
    public interface IResponsePagingBase : IResponseBase
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int TotalFiltered { get; set; }
        public int Total { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponseBase"/>
    /// </summary>
    /// <typeparam name="TEntity"><inheritdoc cref="IResponseBase{TEntity}"/></typeparam>
    public interface IResponsePagingSize<TEntity> : IResponseBase<TEntity>, IResponsePagingBase
    {

    }
}
