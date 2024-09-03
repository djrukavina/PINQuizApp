using System.ComponentModel.DataAnnotations;

namespace QuizAppShared.Data
{
    public class PlayedQuiz
    {
        [Key] public int Id { get; set; }
        [Required] public string UserName { get; set; }
        public string Category { get; set; }
        public int NoQuestionCorrect { get; set; }
        public int NoQuestionTotal { get; set; }
    }
}