using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAppAPI.Services;
using QuizAppAPI.ViewModel;

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

        [HttpGet("username")]
        public IActionResult GetUser([FromQuery]string username)
        {
            var user = UserService.GetUser(username);
            return Ok(user);
        }
    }
}
