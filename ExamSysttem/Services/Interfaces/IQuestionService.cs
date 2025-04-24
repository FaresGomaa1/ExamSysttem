using ExamSysttem.Models;
using ExamSysttem.ViewModels;

namespace ExamSysttem.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionReadForAdmin>> GetAllForAdminAsync(int ExamId);
        Task<List<QuestionReadForStudent>> GetAllForStudentAsync(int ExamId);
        Task<QuestionReadForAdmin?> GetByIdForAdminAsync(int id);
        Task<QuestionReadForStudent?> GetByIdForStudentAsync(int id);
        Task CreateAsync(QuestionCreate question);
        Task UpdateAsync(int Id,QuestionCreate question);
        Task DeleteAsync(int id);
    }
}
