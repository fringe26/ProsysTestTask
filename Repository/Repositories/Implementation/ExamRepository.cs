using DomainModels.Models.ExamModel;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementation
{
    public class ExamRepository : EfCoreRepository<Exam, (int, string)>
    {
      
        public ExamRepository(ExamDbContext context) : base(context)
        {
        }

        public override async Task<Exam> DetailsByKey((int, string) key)
        {
            return await Context.Exams.SingleOrDefaultAsync(e => e.StudentNumber == key.Item1 && e.SubjectCode == key.Item2);
        }
    }
}
