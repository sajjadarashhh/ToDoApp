using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.MessagingBase
{
    public interface IResponseBase
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }
        ApplicationCodes Code { get; set; }
    }
    public interface IResponseBase<TEntity> : IResponseBase
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }
    public interface IResponsePagingBase : IResponseBase
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int TotalFiltered { get; set; }
        public int Total { get; set; }
    }
    public interface IResponsePagingSize<TEntity> : IResponseBase<TEntity>, IResponsePagingBase
    {

    }
}
