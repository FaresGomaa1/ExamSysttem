using ExamSysttem.Data;
using ExamSysttem.Models;
using ExamSysttem.Services.Interfaces;
using ExamSysttem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSysttem.Services.Classes
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionReadForAdmin>> GetAllForAdminAsync(int examId)
        {
            return await _context.Questions
                .Include(q => q.Exam)
                .Where(q => q.ExamId == examId)
                .Select(q => new QuestionReadForAdmin
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    ChoiceA = q.ChoiceA,
                    ChoiceB = q.ChoiceB,
                    ChoiceC = q.ChoiceC,
                    ChoiceD = q.ChoiceD,
                    CorrectAnswer = q.CorrectAnswer,
                    Exam = new ExamRead
                    {
                        Id = q.Exam.Id,
                        Name = q.Exam.Name,
                        Description = q.Exam.Description,
                        CreatedOn = q.Exam.CreatedOn
                    }
                })
                .ToListAsync();
        }

        public async Task<List<QuestionReadForStudent>> GetAllForStudentAsync(int examId)
        {
            return await _context.Questions
                .Include(q => q.Exam)
                .Where(q => q.ExamId == examId)
                .Select(q => new QuestionReadForStudent
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    ChoiceA = q.ChoiceA,
                    ChoiceB = q.ChoiceB,
                    ChoiceC = q.ChoiceC,
                    ChoiceD = q.ChoiceD,
                    Exam = new ExamRead
                    {
                        Id = q.Exam.Id,
                        Name = q.Exam.Name,
                        Description = q.Exam.Description,
                        CreatedOn = q.Exam.CreatedOn
                    }
                })
                .ToListAsync();
        }

        public async Task<QuestionReadForAdmin?> GetByIdForAdminAsync(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Exam)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return null;

            return new QuestionReadForAdmin
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                ChoiceA = question.ChoiceA,
                ChoiceB = question.ChoiceB,
                ChoiceC = question.ChoiceC,
                ChoiceD = question.ChoiceD,
                CorrectAnswer = question.CorrectAnswer,
                Exam = new ExamRead
                {
                    Id = question.Exam.Id,
                    Name = question.Exam.Name,
                    Description = question.Exam.Description,
                    CreatedOn = question.Exam.CreatedOn
                }
            };
        }

        public async Task<QuestionReadForStudent?> GetByIdForStudentAsync(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Exam)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return null;

            return new QuestionReadForStudent
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                ChoiceA = question.ChoiceA,
                ChoiceB = question.ChoiceB,
                ChoiceC = question.ChoiceC,
                ChoiceD = question.ChoiceD,
                Exam = new ExamRead
                {
                    Id = question.Exam.Id,
                    Name = question.Exam.Name,
                    Description = question.Exam.Description,
                    CreatedOn = question.Exam.CreatedOn
                }
            };
        }

        public async Task CreateAsync(QuestionCreate question)
        {
            var newQuestion = new Question
            {
                QuestionText = question.QuestionText,
                ExamId = question.ExamId,
                ChoiceA = question.ChoiceA,
                ChoiceB = question.ChoiceB,
                ChoiceC = question.ChoiceC,
                ChoiceD = question.ChoiceD,
                CorrectAnswer = question.CorrectAnswer
            };

            _context.Questions.Add(newQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id,QuestionCreate question)
        {
            var existingQuestion = await _context.Questions.FindAsync(Id);
            if (existingQuestion == null)
            {
                throw new KeyNotFoundException("Question not found");
            }

            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.ChoiceA = question.ChoiceA;
            existingQuestion.ChoiceB = question.ChoiceB;
            existingQuestion.ChoiceC = question.ChoiceC;
            existingQuestion.ChoiceD = question.ChoiceD;
            existingQuestion.CorrectAnswer = question.CorrectAnswer;

            _context.Questions.Update(existingQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
}
