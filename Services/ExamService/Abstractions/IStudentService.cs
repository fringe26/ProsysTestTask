using DomainModels.Models.ExamModel;

namespace Services.ExamService.Abstractions
{
    public interface IStudentService
    {
        Task<bool> CreateAsync(Student subject);
        Task<Student> GetAsync(int id);
        Task<IList<Student>> GetAllAsync();
        Task<bool> UpdateAsync(Student subject);
        Task<bool> DeleteAsync(Student subject);
    }
}
