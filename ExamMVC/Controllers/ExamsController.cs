using Microsoft.AspNetCore.Mvc;
using DomainModels.Models.ExamModel;
using Services.ExamService.Abstractions;
using ExamMVC.ViewModels;

namespace ExamMVC.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        
        public ExamsController(IExamService examService, IStudentService studentService, ISubjectService subjectService)
        {
            _examService = examService;
            _studentService = studentService;
            _subjectService = subjectService;
        }

 
        public async Task<IActionResult> Index()
        {
           
            return View(await _examService.GetAllAsync());
        }


        public async Task<IActionResult> Details((int, string) id)
        {
            var exam = await _examService.GetAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

   
        public async Task<IActionResult> Create()
        {
            var viewModel = new ExamViewModel
            {
              
              Subjects = await _subjectService.GetAllAsync(),
              Students = await _studentService.GetAllAsync()

            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamViewModel examViewModel)
        {
          

            if (ModelState.IsValid)
            {
                var exam = new Exam
                {
                    ExamDate = examViewModel.ExamDate,
                    Grade = examViewModel.Grade,
                    StudentNumber = examViewModel.StudentNumber,
                    SubjectCode = examViewModel.SubjectCode
                };

                var result = await _examService.CreateAsync(exam);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            // Если мы дошли до этого места, что-то пошло не так, повторно заполните DropBoxViewModel
           

            return View(examViewModel);
        }




        public async Task<IActionResult> Edit(int studentNumber, string subjectCode)
        {
            var exam = await _examService.GetAsync((studentNumber,subjectCode));
            if (exam == null)
            {
                return NotFound();
            }

            var viewModel = new ExamViewModel
            {
              
              Subjects = await _subjectService.GetAllAsync() ,
              Students = await _studentService.GetAllAsync(),
            
                Grade = exam.Grade,
                ExamDate = exam.ExamDate,
            };

            return View(viewModel);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int studentNumber, string subjectCode, [Bind("ExamDate,Grade,StudentNumber,SubjectCode")] ExamViewModel examViewModel)
        {
            var exam = new Exam();
            if (!(studentNumber,subjectCode).Equals((examViewModel.StudentNumber, examViewModel.SubjectCode)))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 exam = new Exam
                {
                    Grade = examViewModel.Grade,
                    ExamDate = examViewModel.ExamDate,
                    StudentNumber = examViewModel.StudentNumber,
                    SubjectCode = examViewModel.SubjectCode
                };

                var result = await _examService.UpdateAsync(exam);
                if (result)
                    return RedirectToAction(nameof(Index));

                return View(exam);
            }
            return View(exam);
        }


        public async Task<IActionResult> Delete(int studentNumber, string subjectCode)
        {
            var exam = await _examService.GetAsync((studentNumber,subjectCode));
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int studentNumber, string subjectCode)
        {
            var exam = await _examService.GetAsync((studentNumber, subjectCode));
            if (exam != null)
            {
                var result = await _examService.DeleteAsync(exam);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
