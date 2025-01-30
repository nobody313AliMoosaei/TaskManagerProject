using System.ComponentModel.DataAnnotations;
using TaskManagerRoom308.Data.Entities;

namespace TaskManagerRoom308.DTO.AddNewTask
{
    public class AddNewTaskCommand
    {
        [Required(ErrorMessage ="ارسال عنوان اجباری است")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage ="لول را تعیین کنید")]
        public TaskLevel TaskLevel { get; set; } = TaskLevel.None;
        public string? Tag { get; set; }
    }
}
