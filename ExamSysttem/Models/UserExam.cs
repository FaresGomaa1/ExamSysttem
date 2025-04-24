using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSysttem.Models
{
    public class UserExam
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public float Result { get; set; }

        public bool Passed { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
