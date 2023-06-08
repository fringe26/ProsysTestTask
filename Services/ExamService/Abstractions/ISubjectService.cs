using DomainModels.Models.ExamModel;

namespace Services.ExamService.Abstractions
{
    public interface ISubjectService
    {
        Task<bool> CreateAsync(Subject subject);
        Task<Subject> GetAsync(string id);
        Task<IList<Subject>> GetAllAsync();
        Task<bool> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(Subject subject);

     
    }
}
