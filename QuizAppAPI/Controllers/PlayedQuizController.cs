using Microsoft.AspNetCore.Mvc;
using QuizAppAPI.Services;
using QuizAppShared.ViewModel;

namespace QuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedQuizController : ControllerBase
    {
        public PlayedQuizService PlayedQuizService { get; set; }
        public PlayedQuizController(PlayedQuizService quizService)
        {
            PlayedQuizService = quizService;
        }

        [HttpPost]
        public IActionResult AddPlayedQuiz([FromBody]PlayedQuizVM playedQuiz)
        {
            PlayedQuizService.AddPlayedQuiz(playedQuiz);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPlayedQuizzes()
        {
            var playedQuizzes = PlayedQuizService.GetPlayedQuizzes();
            return Ok(playedQuizzes);
        }

        [HttpGet("username")]
        public IActionResult GetUserPlayedQuizzes([FromQuery] string username)
        {
            var playedQuizzes = PlayedQuizService.GetUserPlayedQuizzes(username);
            return Ok(playedQuizzes);
        }
    }
}
