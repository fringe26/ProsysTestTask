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
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _repository;
        public StudentService(StudentRepository repository) { _repository = repository; }

        public Task<bool> CreateAsync(Student student)
        {
            return _repository.AddAsync(student);
        }

        public Task<bool> DeleteAsync(Student student)
        {
            return _repository.DeleteAsync(student);
        }

        public Task<IList<Student>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Student> GetAsync(int key)
        {
            return _repository.DetailsByKey(key);
        }

        public Task<bool> UpdateAsync(Student student)
        {
            return _repository.Update(student);
        }
    }
}
