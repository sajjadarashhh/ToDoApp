using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Interfaces
{
    /// <summary>
    /// کاربر فعلی که درخواست کار کردن با سامانه دارد
    /// </summary>
    public interface ICurrentUser
    {
        Guid Id { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        List<Permissions> Permissions { get; set; }
    }
}
