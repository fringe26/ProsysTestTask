using DomainModels.Models.ExamModel;

namespace ExamMVC.ViewModels
{
    public class DropBoxViewModel
    {
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}
