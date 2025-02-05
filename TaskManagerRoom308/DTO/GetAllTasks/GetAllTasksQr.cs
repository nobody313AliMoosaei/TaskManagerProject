using TaskManagerRoom308.Data.Entities;

namespace TaskManagerRoom308.DTO.GetAllTasks
{
    public class GetAllTasksQr
    {
        public long TaskId { get; set; }
        public string? Title { get; set; }
        public string? Dsr { get; set; }
        public TaskLevel TaskLevel { get; set; }
        public string? Tag { get; set; }
    }
}
