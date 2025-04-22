using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSysttem.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }

        [ForeignKey("UserExam")]
        public int UserExamId { get; set; }

        public virtual UserExam UserExam { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        [ForeignKey("Choice")]
        public int SelectedChoiceId { get; set; }

        public virtual Choice SelectedChoice { get; set; }

        public bool IsCorrect { get; set; }
    }
}
