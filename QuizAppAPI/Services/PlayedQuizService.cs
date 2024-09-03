using QuizAppAPI.Context;
using QuizAppShared.ViewModel;
using QuizAppShared.Data;

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

        public List<PlayedQuizVM> GetPlayedQuizzes()
        {
            var playedQuizzes = _context.PlayedQuiz.ToList();
            var playedQuizzesVM = new List<PlayedQuizVM>();
            foreach (var quiz in playedQuizzes)
            {
                playedQuizzesVM.Add(new PlayedQuizVM
                {
                    Username = quiz.UserName,
                    Category = quiz.Category,
                    NoQuestionCorrect = quiz.NoQuestionCorrect,
                    NoQuestionTotal = quiz.NoQuestionTotal
                });
            }
            return playedQuizzesVM;
        }

        public List<PlayedQuizVM> GetUserPlayedQuizzes(string username)
        {
            var playedQuizzes = _context.PlayedQuiz.Where(x => x.UserName == username).ToList();
            var playedQuizzesVM = new List<PlayedQuizVM>();
            foreach (var quiz in playedQuizzes)
            {
                playedQuizzesVM.Add(new PlayedQuizVM
                {
                    Username = quiz.UserName,
                    Category = quiz.Category,
                    NoQuestionCorrect= quiz.NoQuestionCorrect,
                    NoQuestionTotal= quiz.NoQuestionTotal
                });
            }
            return playedQuizzesVM;
        }
    }
}
