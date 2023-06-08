using DomainModels.Models.ExamModel;

namespace ExamMVC.ViewModels
{
    public class DropBoxViewModel
    {
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
