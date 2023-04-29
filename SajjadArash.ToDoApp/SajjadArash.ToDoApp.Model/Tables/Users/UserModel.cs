using SajjadArash.ToDoApp.Infrastructure.ModelSuperBase;
using SajjadArash.ToDoApp.Model.Tables.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SajjadArash.ToDoApp.Model.Tables.Users
{
    /// <summary>
    /// نمایندگی اطلاعات کاربر
    /// </summary>
    public class UserModel : ModelBase<Guid>
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        /// <summary>
        /// کلمه عبور
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
        public IList<TasksModel> Tasks { get; set; }
    }
}
