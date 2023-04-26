using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Exceptions
{
    /// <summary>
    /// خطای سطح دسترسی
    /// </summary>
    public class NotAccessException : ToDoAppExceptionBase
    {
        public NotAccessException() : base("you dont have Access to this Action.")
        {
        }

        public override ApplicationCodes Code => ApplicationCodes.NotAccess;
    }
}
