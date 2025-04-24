using ExamSysttem.Models;
using ExamSysttem.ViewModels;

namespace ExamSysttem.Services.Interfaces
{
    public interface IExamService
    {
        Task<List<ExamRead>> GetAllAsync();
        Task<ExamRead?> GetByIdAsync(int id);
        Task CreateAsync(ExamCreate model);
        Task UpdateAsync(int id, ExamEdit model);
        Task DeleteAsync(int id);

    }
}
