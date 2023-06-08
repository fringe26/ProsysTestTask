using DomainModels.Models.ExamModel;
using System.ComponentModel.DataAnnotations;

namespace ExamMVC.ViewModels
{

    public class ExamViewModel
    {
        [Required]
        public DateTime ExamDate { get; set; } = new System.DateTime(2019, 1, 1);

        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }
        public int StudentNumber { get; set; }
        public string SubjectCode { get; set; }
        public DropBoxViewModel DropBoxViewModel { get; set; } = new DropBoxViewModel();
    }

}
