namespace QuizAppShared.ViewModel
{
    public class PlayedQuizVM
    {
        public string Username { get; set; }
        public string Category { get; set; }
        public int NoQuestionCorrect { get; set; }
        public int NoQuestionTotal { get; set; }
    }
}
