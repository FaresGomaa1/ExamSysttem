using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSysttem.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        // Navigation property
        public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();
    }
}
