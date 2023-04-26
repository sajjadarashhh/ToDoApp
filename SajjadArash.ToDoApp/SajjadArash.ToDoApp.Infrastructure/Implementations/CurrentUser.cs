using SajjadArash.ToDoApp.Infrastructure.Common.Interfaces;
using SajjadArash.ToDoApp.Infrastructure.Enums;

namespace SajjadArash.ToDoApp.Infrastructure.Implementations
{
    /// <summary>
    /// <inheritdoc cref="ICurrentUser"/>
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}
