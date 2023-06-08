using DomainModels.Models.ExamModel;

namespace Services.ExamService.Abstractions
{
    public interface IExamService
    {
        Task<bool> CreateAsync(Exam exam);
        Task<Exam> GetAsync(string id);
        Task<IList<Exam>> GetAllAsync();
        Task<bool> UpdateAsync(Exam subject);
        Task<bool> DeleteAsync(Exam subject);
    }
}
