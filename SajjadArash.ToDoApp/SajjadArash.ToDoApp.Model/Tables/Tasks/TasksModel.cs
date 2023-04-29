using SajjadArash.ToDoApp.Infrastructure.ModelSuperBase;
using SajjadArash.ToDoApp.Model.Tables.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SajjadArash.ToDoApp.Model.Tables.Tasks
{
    /// <summary>
    /// وضعیت های تسک ها
    /// </summary>
    public enum State
    {
        /// <summary>
        /// در حالت انتظار
        /// </summary>
        Pending,
        /// <summary>
        /// در حال انجام
        /// </summary>
        Working,
        /// <summary>
        /// پایان یافته
        /// </summary>
        Finished,
    }
    /// <summary>
    /// نمایندگی اطلاعات تسک ها
    /// </summary>
    public class TasksModel : ModelBase<Guid>
    {
        /// <summary>
        /// عنوان تسک
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// توضیحات تسک
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ پایان تسک
        /// </summary>
        [Required]
        public DateTime DeathLine { get; set; }
        /// <summary>
        /// وضعیت تسک
        /// </summary>
        public State HasFinished { get; set; }
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }
    }
}
