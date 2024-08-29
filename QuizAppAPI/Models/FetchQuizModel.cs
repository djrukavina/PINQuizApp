namespace QuizAppAPI.Models
{
    public class FetchQuizModel
    {
        public int response_code { get; set; }
        public QuestionModel[] results { get; set; }
    }
}
