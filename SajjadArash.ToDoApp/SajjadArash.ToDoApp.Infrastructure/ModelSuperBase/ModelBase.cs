namespace SajjadArash.ToDoApp.Infrastructure.ModelSuperBase
{
    /// <summary>
    /// بیس تمامی جداول
    /// </summary>
    public abstract class ModelBase
    {
        public Guid? CreatedUserId { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public Guid? DeletedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
    /// <summary>
    /// بیس موجودی هایی که آیدی دارند
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class ModelBase<TId>:ModelBase
    {
        public TId Id { get; set; }
    }
    /// <summary>
    /// بیس جداول واسط
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class ValueObjectBase:ModelBase
    {
        
    }
}
