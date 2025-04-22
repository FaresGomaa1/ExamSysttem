using Microsoft.AspNetCore.Identity;

namespace ExamSysttem.Models
{
    public class User : IdentityUser
    {
        // Navigation property
        public virtual ICollection<UserExam> UserExams { get; set; } = new List<UserExam>();
    }
}
