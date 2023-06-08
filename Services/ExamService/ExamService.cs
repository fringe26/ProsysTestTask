using DomainModels.Models.ExamModel;
using Repository.Repositories.Implementation;
using Services.ExamService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExamService
{
    public class ExamService : IExamService
    {
        private readonly ExamRepository _repository;

        public ExamService(ExamRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Exam exam)
        {
            return await _repository.AddAsync(exam);
        }

        public async Task<Exam> GetAsync((int, string) id)
        {
            return await _repository.DetailsByKey(id);
        }

        public async Task<IList<Exam>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(Exam exam)
        {
            return await _repository.Update(exam);
        }

        public async Task<bool> DeleteAsync(Exam exam)
        {
            return await _repository.DeleteAsync(exam);
        }
    }
}
