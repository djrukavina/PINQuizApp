using QuizAppAPI.Context;
using QuizAppAPI.ViewModel;
using QuizAppShared.Data;

namespace QuizAppAPI.Services
{
    public class UserService
    {
        private AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var newUser = new User()
            {
                UserName = user.Name,
                UserPassword = user.Password,
                UserEmail = user.Email,
                Role = "User"
            };
            _context.User.Add(newUser);
            _context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public User GetUser(string username, string password)
        {
            return _context.User.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
        }
    }
}
