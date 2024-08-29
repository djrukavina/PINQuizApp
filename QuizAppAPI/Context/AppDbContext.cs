using Microsoft.EntityFrameworkCore;
using QuizAppAPI.Data;
using QuizAppShared.Data;

namespace QuizAppAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<PlayedQuiz> PlayedQuiz { get; set; }
    }
}