using DomainModels.Models.ExamModel;
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
        public Task<bool> CreateAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Exam subject)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exam> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Exam subject)
        {
            throw new NotImplementedException();
        }
    }
}
