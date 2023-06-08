using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DomainModels.Models.ExamModel
{
    public class Exam
    {
        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }

        [Required]
        public int StudentNumber { get; set; }

        [ForeignKey("StudentNumber")]
        public Student Student { get; set; }

        [Required]
        public string SubjectCode { get; set; }

        [ForeignKey("SubjectCode")]
        public Subject Subject { get; set; }
    }

}
