using System.ComponentModel.DataAnnotations;


namespace DomainModels.Models.ExamModel
{
    public class Subject
    {
        [Required]
        [StringLength(3)]
        public string SubjectCode { get; set; }

        [Required]
        [StringLength(30)]
        public string SubjectName { get; set; }

        [Required]
        [Range(1, 12)]
        public int Class { get; set; }

        [Required]
        [StringLength(20)]
        public string TeacherFirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string TeacherLastName { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }

}
