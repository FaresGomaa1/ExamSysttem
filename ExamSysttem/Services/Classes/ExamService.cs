using ExamSysttem.Data;
using ExamSysttem.Models;
using ExamSysttem.Services.Interfaces;
using ExamSysttem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamSysttem.Services.Classes
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext _context;

        public ExamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamRead>> GetAllAsync()
        {
            return await _context.Exams
                .Include(e => e.Questions)
                .Select(e => new ExamRead
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn,
                    NumberOfQuestions = e.Questions.Count,
                })
                .ToListAsync();
        }

        public async Task<ExamRead?> GetByIdAsync(int id)
        {
            return await _context.Exams
                .Include(e => e.Questions)
                .Where(e => e.Id == id)
                .Select(e => new ExamRead
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn,
                    NumberOfQuestions = e.Questions.Count,
                })
                .FirstOrDefaultAsync();
        }
        public async Task CreateAsync(ExamCreate model)
        {
            var exam = new Exam
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow
            };
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ExamEdit model)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) throw new ArgumentException("Exam not found");

            exam.Name = model.Name;
            exam.Description = model.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) throw new ArgumentException("Exam not found");

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }
    }
}
