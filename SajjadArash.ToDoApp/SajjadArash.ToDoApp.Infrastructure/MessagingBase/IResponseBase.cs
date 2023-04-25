using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.MessagingBase
{
    public interface IResponseBase
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }
        ApplicationCodes Code { get; set; }
    }
    public class ResponseBase : IResponseBase
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ApplicationCodes Code { get; set; }
    }
}
