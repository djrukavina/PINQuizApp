using Microsoft.AspNetCore.Mvc;
using QuizAppAPI.Services;
using QuizAppAPI.ViewModel;
using QuizAppShared.Data;

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
        public IActionResult GetUsers()
        {
            var users = UserService.GetUsers();
            return Ok(users);
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
