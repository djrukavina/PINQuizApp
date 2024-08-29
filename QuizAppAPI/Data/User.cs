using System.ComponentModel.DataAnnotations;

namespace QuizAppAPI.Data
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string UserEmail { get; set; }
        [Required] public string UserPassword { get; set; }
        public string Role { get; set; }
    }
}