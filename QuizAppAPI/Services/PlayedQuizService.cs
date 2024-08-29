using Microsoft.EntityFrameworkCore;
using QuizAppAPI.Context;
using QuizAppAPI.Data;
using QuizAppAPI.ViewModel;

namespace QuizAppAPI.Services
{
    public class PlayedQuizService
    {
        private AppDbContext _context;
        public PlayedQuizService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPlayedQuiz(PlayedQuizVM playedQuiz)
        {
            var newPlayedQuiz = new PlayedQuiz()
            {
                UserName = playedQuiz.Username,
                Category = playedQuiz.Category,
                NoQuestionCorrect = playedQuiz.NoQuestionCorrect,
                NoQuestionTotal = playedQuiz.NoQuestionTotal
            };
            _context.PlayedQuiz.Add(newPlayedQuiz);
            _context.SaveChanges();
        }

        public List<PlayedQuiz> GetPlayedQuizzes()
        {
            return _context.PlayedQuiz.ToList();
        }

        public List<PlayedQuiz> GetUserPlayedQuizzes(string username)
        {
            return _context.PlayedQuiz.Where(x => x.UserName == username).ToList();
        }
    }
}
