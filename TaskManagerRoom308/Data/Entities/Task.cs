namespace TaskManagerRoom308.Data.Entities
{
    public partial class Task
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TaskLevel TaskLevel { get; set; } = TaskLevel.None;
        public string? Tag { get; set; }

        #region Navigations
        public virtual ICollection<UserTask> UserTasks { get; set; } = new HashSet<UserTask>();
        #endregion
    }

    public enum TaskLevel
    {
        None = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3,
        VeryHard = 4
    }
}
