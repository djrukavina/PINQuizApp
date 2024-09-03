﻿using QuizAppShared.Data;

namespace QuizAppUI.Components.Authentication
{
    public class ValidatedUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public ValidatedUserService(HttpClient httpClient, IConfiguration configuration)
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
    }
}