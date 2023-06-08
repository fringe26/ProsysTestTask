using DomainModels.Models.ExamModel;
using Repository.DAL;
using Repository.Repositories.Implementation;
using Services.ExamService.Abstractions;

namespace Services.ExamService
{
    public class SubjectService : ISubjectService
    {

        private readonly SubjectRepository _repository;
        public SubjectService(SubjectRepository repository) { _repository = repository; }

        public Task<bool> CreateAsync(Subject subject)
        {
            return _repository.AddAsync(subject);
        }

        public Task<bool> DeleteAsync(Subject subject)
        {
            return _repository.DeleteAsync(subject);
        }

        public Task<IList<Subject>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Subject> GetAsync(string key)
        {
            return _repository.DetailsByKey(key);
        }

        public Task<bool> UpdateAsync(Subject subject)
        {
            return _repository.Update(subject);
        }
    }
}
