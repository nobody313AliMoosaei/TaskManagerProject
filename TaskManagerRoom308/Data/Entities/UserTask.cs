namespace TaskManagerRoom308.Data.Entities
{
    public partial class UserTask
    {
        public long Id { get; set; }
        public long UserRef { get; set; }
        public long TaskRef { get; set; }
        public UserTaskStatus UserTaskStatus { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyDateTime { get; set; }

        #region Navigations
        public virtual User UserRefNavigation { get; set; } = null!;
        public virtual Entities.Task TaskRefNavigation { get; set; } = null!;

        #endregion
    }
    public enum UserTaskStatus
    {
        None = 0,
        Doing = 1,
        Done = 2,
        Failed = 3
    }
}
