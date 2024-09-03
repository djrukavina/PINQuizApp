using QuizAppShared.Data;
using QuizAppShared.ViewModel;


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

        public async Task<List<Question>> GetQuestionsForQuiz(string amount, string category, string difficulty)
        {
            int amountAPI = int.Parse(amount);
            int categoryAPI = QuizSettings.QuizCategories.FirstOrDefault(x => x.Value == category).Key;
            int difficultyAPI = QuizSettings.QuizDifficulty.FirstOrDefault(x => x.Value == difficulty).Key;
            List<Question> questionList = new List<Question>();

            try
            {
                questionList = await _httpClient.GetFromJsonAsync<List<Question>>($"{_apiUrl}/QuizData/quizParams?amount={amountAPI}&category={categoryAPI}&difficulty={difficultyAPI}");
            }
            catch
            {
                return null;
            }
            return questionList;
        }

        public async Task SubmitQuizResult(PlayedQuizVM playedQuiz)
        {
            try
            {
                await _httpClient.PostAsJsonAsync($"{_apiUrl}/PlayedQuiz", playedQuiz);
            }
            catch
            {
                Console.WriteLine("data was not sent");
            }
        }
    }
}
