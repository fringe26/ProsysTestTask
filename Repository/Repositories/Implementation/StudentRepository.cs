﻿using DomainModels.Models.ExamModel;
using Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementation
{
    public class StudentRepository : EfCoreRepository<Student,int>
    {
        public ExamDbContext appDbContext { get { return _context; } }

        public StudentRepository(ExamDbContext context) : base(context)
        {
        }
    }
}