using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerRoom308.DTO.AddNewTask;
using TaskManagerRoom308.Services;

namespace TaskManagerRoom308.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewTask(AddNewTaskCommand command)
        {
            var result = await _taskService.AddNewTask(command);
            if (result)
                return Ok();
            return BadRequest();
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTasks()
        {
            var Result = await _taskService.GetAllTasks();
            return Ok(Result);
        }
    }
}
