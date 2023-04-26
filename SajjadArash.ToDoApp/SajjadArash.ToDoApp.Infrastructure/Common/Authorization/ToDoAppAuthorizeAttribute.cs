using SajjadArash.ToDoApp.Infrastructure.Enums;
using SajjadArash.ToDoApp.Infrastructure.MessagingBase;
namespace SajjadArash.ToDoApp.Infrastructure.Common.Authorization
{

    /// <summary>
    /// جهت محدود کردن سطوح دسترسی که به <see cref="IRequestBase" /> دسترسی دارند
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ToDoAppAuthorizeAttribute : Attribute
    {
        public Permissions Permission { get; set; }
    }
}
