using ExamSysttem.Models;
using System.ComponentModel.DataAnnotations;

namespace ExamSysttem.ViewModels
{
    public class ExamCreate
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }

    public class ExamRead
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }
        public int NumberOfQuestions { get; set; }
    }

    public class ExamEdit
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
