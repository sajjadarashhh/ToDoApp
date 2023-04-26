using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Exceptions
{
    public abstract class ToDoAppExceptionBase : Exception
    {
        public abstract ApplicationCodes Code { get; }
        public ToDoAppExceptionBase(string message) : base(message)
        {

        }
    }
}
