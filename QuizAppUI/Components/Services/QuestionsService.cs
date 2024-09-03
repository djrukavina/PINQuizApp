using QuizAppShared.Data;

namespace QuizAppUI.Components.Services
{
    public class QuestionsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public QuestionsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ServerAPI");
        }

        public async Task<List<Question>> GetQuestionsForQuiz()
        {
            int amount = 8;
            int category = 21;
            int difficulty = 0;
            List<Question> questionList = new List<Question>();

            try
            {
                questionList = await _httpClient.GetFromJsonAsync<List<Question>>($"{_apiUrl}/QuizData/quizParams?amount={amount}&category={category}&difficulty={difficulty}");
            }
            catch
            {
                return null;
            }
            return questionList;
        }
    }
}
