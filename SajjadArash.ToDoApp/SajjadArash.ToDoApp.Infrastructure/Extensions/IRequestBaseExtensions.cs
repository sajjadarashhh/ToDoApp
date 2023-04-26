using MediatR;
using SajjadArash.ToDoApp.Infrastructure.Enums;
using SajjadArash.ToDoApp.Infrastructure.MessagingBase;
using System.Security.Cryptography.X509Certificates;

namespace SajjadArash.ToDoApp.Infrastructure.Extensions
{
    /// <summary>
    /// <inheritdoc cref="IResponseBase"/>
    /// </summary>
    internal record ResponseBase : IResponseBase
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ApplicationCodes Code { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponseBase{TEntity}"/>
    /// </summary>
    internal record ResponseBase<TEntity> : ResponseBase, IResponseBase<TEntity> where TEntity : IViewModelBase
    {
        public TEntity Entity { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponsePagingBase"/>
    /// </summary>
    internal record ResponsePagingBase : ResponseBase, IResponsePagingBase
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int TotalFiltered { get; set; }
        public int Total { get; set; }
    }
    /// <summary>
    /// <inheritdoc cref="IResponsePagingBase{TEntity}"/>
    /// </summary>
    internal record ResponsePagingBase<TEntity> : ResponsePagingBase, IResponsePagingBase<TEntity> where TEntity : IViewModelBase
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }

    public static class IRequestBaseExtensions
    {
        /// <summary>
        /// سازنده اصلی خروجی هایی که بیانگر موفقیت امیز بودن عملیات هستند
        /// </summary>
        /// <returns></returns>
        private static IResponseBase Success() => new ResponseBase()
        {
            Code = ApplicationCodes.Success,
            IsSuccess = true,
            Message = "operation success."
        };
        /// <summary>
        /// سازنده اصلی خروجی هایی که بیانگر موفقیت امیز بودن عملیات هستند
        /// </summary>
        /// <returns></returns>
        private static IResponseBase Success(int index, int size, int total, int totalFilteredCount) => new ResponsePagingBase()
        {
            Code = ApplicationCodes.Success,
            IsSuccess = true,
            Message = "operation success.",
            Index = index,
            Size = size,
            Total = total,
            TotalFiltered = totalFilteredCount
        };
        /// <summary>
        /// ایجاد خروجی هایی که مشخص کننده خطای داخل پروژه هستند
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Exception<TResponse>(this IRequestBase request, ApplicationCodes code = ApplicationCodes.Exception, string message = null) where TResponse : IResponseBase
        {
            return new ResponseBase()
            {
                Code = code,
                Message = message ?? "Not Handle Exception",
                IsSuccess = false
            };
        }
        /// <summary>
        /// ایجاد خروجی که بیانگر موفقیت امیز بودن پروژه است
        /// </summary>
        /// <typeparam name="TEntity">ورودی کاربر</typeparam>
        /// <typeparam name="TResponse">خروجی</typeparam>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IResponseBase Success<TEntity, TResponse>(this IRequestBase<TEntity, TResponse> request, TResponse response) where TEntity : IViewModelBase where TResponse : IViewModelBase
        {
            return new ResponseBase<TResponse>()
            {
                Code = ApplicationCodes.Success,
                Entity = response,
                IsSuccess = true,
                Message = "operation success."
            };
        }
        /// <summary>
        /// <inheritdoc cref="Success{TEntity, TResponse}(IRequestBase{TEntity, TResponse}, TResponse)"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Success(this IRequestBase request)
            => Success();
        /// <summary>
        /// <inheritdoc cref="Success{TEntity, TResponse}(IRequestBase{TEntity, TResponse}, TResponse)"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Success<TEntity>(this IRequestBase<TEntity> request) where TEntity : IViewModelBase
            => Success();
        /// <summary>
        /// <inheritdoc cref="Success{TEntity, TResponse}(IRequestBase{TEntity, TResponse}, TResponse)"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Success(this IRequestPagingBase request, int total = 0, int totalFilteredCount = 0)
             => Success(request.Index, request.Size, total, totalFilteredCount);
        /// <summary>
        /// <inheritdoc cref="Success{TEntity, TResponse}(IRequestBase{TEntity, TResponse}, TResponse)"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Success<TEntity>(this IRequestPagingBase<TEntity> request, int total = 0, int totalFilteredCount = 0) where TEntity : IViewModelBase
             => Success(request.Index, request.Size, total, totalFilteredCount);
        /// <summary>
        /// <inheritdoc cref="Success{TEntity, TResponse}(IRequestBase{TEntity, TResponse}, TResponse)"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IResponseBase Success<TEntity, TResponse>(this IRequestPagingBase<TEntity, TResponse> request, IEnumerable<TResponse> response, int total = 0, int totalFilteredCount = 0) where TEntity : IViewModelBase where TResponse : IViewModelBase
        {
            return new ResponsePagingBase<TResponse>()
            {
                Code = ApplicationCodes.Success,
                Entities = response,
                IsSuccess = true,
                Message = "operation success.",
                Index = request.Index,
                Size = request.Size,
                Total = total,
                TotalFiltered = totalFilteredCount
            };
        }
    }
}
