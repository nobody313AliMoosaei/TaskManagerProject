namespace TaskManagerRoom308.Data.Entities
{
    public partial class User
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        #region Navigations
        public virtual ICollection<UserTask> UserTasks { get; set; } = new HashSet<UserTask>();
        #endregion
    }
}
