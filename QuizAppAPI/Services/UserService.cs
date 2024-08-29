using QuizAppAPI.Context;
using QuizAppAPI.Data;
using QuizAppAPI.ViewModel;

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

        public User GetUser(string username)
        {
            return _context.User.FirstOrDefault(x => x.UserName == username);
        }
    }
}
