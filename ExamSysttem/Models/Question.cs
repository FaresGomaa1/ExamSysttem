using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSysttem.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string ChoiceA { get; set; }
        [Required]
        public string ChoiceB { get; set; }
        [Required]
        public string ChoiceC { get; set; }
        [Required]
        public string ChoiceD { get; set; }
        [Required]
        public string CorrectAnswer {  get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
