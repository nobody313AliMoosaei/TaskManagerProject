using Microsoft.EntityFrameworkCore;
using TaskManagerRoom308.Data.Database;
using TaskManagerRoom308.DTO.AddNewTask;
using TaskManagerRoom308.DTO.GetAllTasks;

namespace TaskManagerRoom308.Services
{
    public class TaskService
    {
        private Application_dbContext _dbContext;
        public TaskService(Application_dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public async Task<bool> AddNewTask(AddNewTaskCommand command)
        {
            var entity = new TaskManagerRoom308.Data.Entities.Task
            {
                Description = command.Description,
                Title = command.Title,
                TaskLevel = command.TaskLevel,
                Tag = command.Tag
            };
            _dbContext.Tasks.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetAllTasksQr>> GetAllTasks()
        {
            var query = _dbContext.Tasks
                .Select(e => new GetAllTasksQr
                {
                    TaskId = e.Id,
                    Title = e.Title,
                    Dsr = e.Description,
                    Tag = e.Tag,
                    TaskLevel = e.TaskLevel
                }).AsQueryable();

            return await query.ToListAsync();
        }
    }
}
