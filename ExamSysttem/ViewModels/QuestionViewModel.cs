using ExamSysttem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSysttem.ViewModels
{
    public class QuestionCreate
    {
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int ExamId { get; set; }
        [Required]
        public string ChoiceA { get; set; }
        [Required]
        public string ChoiceB { get; set; }
        [Required]
        public string ChoiceC { get; set; }
        [Required]
        public string ChoiceD { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
    }
    public class QuestionReadForAdmin : QuestionReadForStudent
    {
        public string CorrectAnswer { get; set; }
    }
    public class QuestionReadForStudent
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ExamRead Exam { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
    }
}
