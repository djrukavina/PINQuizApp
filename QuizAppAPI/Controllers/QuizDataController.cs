using Microsoft.AspNetCore.Mvc;
using QuizAppAPI.Models;
using QuizAppAPI.Data;
using QuizAppShared.Data;

namespace QuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizDataController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public QuizDataController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("OpentDbAPI");
        }

        [HttpGet("quizParams")]
        public async Task<IActionResult> GetQuizData(int amount, int category, int difficulty)
        {
            ICollection<int> _category = QuizSettings.QuizCategories.Keys;
            ICollection<int> _difficulty = QuizSettings.QuizDifficulty.Keys;
            FetchQuizModel fetchData = new FetchQuizModel();
            List<Question> questions = new List<Question>();
            string requestString = string.Empty;

            if (amount > 10 || amount <= 0)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Too many or too few questions to get from external API, {category}");
            if (!_category.Contains(category))
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error getting category from external API, {category}");
            if (!_difficulty.Contains(difficulty))
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error getting difficulty from external API, {difficulty}");

            if (category != 1) requestString += $"&category={category}";
            if (difficulty != 0) requestString += $"&difficulty={QuizSettings.QuizDifficulty[difficulty]}";

            try
            {
                fetchData = await _httpClient.GetFromJsonAsync<FetchQuizModel>($"{_apiUrl}?amount={amount}{requestString}&type=multiple");
                foreach (var data in fetchData.results)
                {
                    questions.Add(new Question
                    {
                        question = data.question,
                        difficulty = data.difficulty,
                        category = data.category,
                        correct_answer = data.correct_answer,
                        incorrect_answers = data.incorrect_answers
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from external API, {ex}");
            }
            return Ok(questions);
        }
    }
}
