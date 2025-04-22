using ExamSysttem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamSysttem.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        #region DebSets
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Prevent cascade delete from Question to UserAnswer
            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.Question)
                .WithMany()
                .HasForeignKey(ua => ua.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete from Choice to UserAnswer
            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.SelectedChoice)
                .WithMany()
                .HasForeignKey(ua => ua.SelectedChoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: Prevent cascading from Question to Choices too (if needed)
            builder.Entity<Choice>()
                .HasOne(c => c.Question)
                .WithMany(q => q.Choices)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}