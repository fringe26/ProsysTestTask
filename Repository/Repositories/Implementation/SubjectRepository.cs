using DomainModels.Models.ExamModel;
using Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementation
{
    public class SubjectRepository : EfCoreRepository<Subject,string>
    {
        public SubjectRepository(ExamDbContext context) : base(context)
        {
        }
    }
}
