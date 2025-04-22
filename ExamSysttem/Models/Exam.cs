using System.ComponentModel.DataAnnotations;

namespace ExamSysttem.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<UserExam> UserExams { get; set; } = new List<UserExam>();
    }
}
