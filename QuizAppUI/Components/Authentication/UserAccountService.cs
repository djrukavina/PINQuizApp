namespace QuizAppUI.Components.Authentication
{
    public class UserAccountService
    {
        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount { UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserAccount { UserName = "user", Password = "user", Role = "User" }
            };
        }

        private List<UserAccount> _users;

        public UserAccount? GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
