using Microsoft.AspNetCore.Mvc;
using QuizAppAPI.Services;
using QuizAppShared.Data;
using QuizAppShared.ViewModel;

namespace QuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService UserService { get; set; }
        public UserController(UserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserVM user)
        {
            UserService.AddUser(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult UserExist(string username)
        {
            var exists = UserService.UserCreated(username);
            return Ok(exists);
        }

        [HttpGet("ValidateUser")]
        public IActionResult GetUser(string username, string password)
        {
            var user = UserService.GetUser(username, password);
            if (user == null) return Ok("null");
            var validatedUser = new ValidatedUser
            {
                UserName = user.UserName,
                Role = user.Role
            };
            return Ok(validatedUser);
        }
    }
}
