using Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementation
{
    public class ExamRepository : EfCoreRepository<ExamRepository,string>
    {
        public ExamDbContext ExamDbContext
        {
            get { return _context; }
        }   
        public ExamRepository(ExamDbContext context) : base(context)
        {
        }
    }
}
