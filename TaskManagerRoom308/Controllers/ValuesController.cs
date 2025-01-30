using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerRoom308.DTO.AddNewUser;
using TaskManagerRoom308.Services;

namespace TaskManagerRoom308.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>AddNewUser(addNewUserCommand command)
        {
            var res = await _userService.addNewUser(command);
            if (res)
                return Ok();
            return BadRequest();
        }



    }
}
