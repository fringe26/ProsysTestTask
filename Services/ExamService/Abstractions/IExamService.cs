using DomainModels.Models.ExamModel;

namespace Services.ExamService.Abstractions
{
    public interface IExamService
    {
        Task<bool> CreateAsync(Exam exam);
        Task<Exam> GetAsync((int, string) key);
        Task<IList<Exam>> GetAllAsync();
        Task<bool> UpdateAsync(Exam exam);
        Task<bool> DeleteAsync(Exam exam);
    }
}
