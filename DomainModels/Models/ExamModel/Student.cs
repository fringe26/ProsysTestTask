using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models.ExamModel
{
    public class Student
    {
        [Required]
        [Range(0, 99999)]
        public int StudentNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [Range(1, 12)]
        public int Class { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }

}
