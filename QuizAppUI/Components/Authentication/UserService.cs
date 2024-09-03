using QuizAppShared.Data;
using QuizAppShared.ViewModel;

namespace QuizAppUI.Components.Authentication
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ServerAPI");
        }

        public async Task<ValidatedUser> GetUserByNamePassword(string userName, string password)
        {
            ValidatedUser fetchUser = new ValidatedUser();

            try
            {
                fetchUser = await _httpClient.GetFromJsonAsync<ValidatedUser>($"{_apiUrl}/User/ValidateUser?username={userName}&password={password}");
            }
            catch
            {
                return null;
            }
            return fetchUser;
        }

        public async Task<bool> UserExist(string username)
        {
            return await _httpClient.GetFromJsonAsync<bool>($"{_apiUrl}/User?username={username}");
        }

        public async Task CreateUser(UserVM user)
        {
            try
            {
                await _httpClient.PostAsJsonAsync($"{_apiUrl}/User", user);
            }
            catch
            {
                Console.WriteLine("data was not sent");
            }
        }
    }
}
