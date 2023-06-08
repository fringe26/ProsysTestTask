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
           ;
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
                DropBoxViewModel = new DropBoxViewModel
                {
                    Subjects = await _subjectService.GetAllAsync() as List<Subject>,
                    Students = await _studentService.GetAllAsync() as List<Student>
                }
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Exam.ExamDate,Exam.Grade,Exam.StudentNumber,Exam.SubjectCode")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _examService.CreateAsync(examViewModel.Exam);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            // Если мы дошли до этого места, что-то пошло не так, повторно заполните DropBoxViewModel
            examViewModel.DropBoxViewModel = new DropBoxViewModel
            {
                Subjects = await _subjectService.GetAllAsync() as List<Subject>,
                Students = await _studentService.GetAllAsync() as List<Student>
            };

            return View(examViewModel);
        }




        public async Task<IActionResult> Edit((int, string) id)
        {
            var exam = await _examService.GetAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit((int, string) id, [Bind("ExamDate,Grade,StudentNumber,SubjectCode")] Exam exam)
        {
            if (!id.Equals((exam.StudentNumber, exam.SubjectCode)))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _examService.UpdateAsync(exam);
                if (result)
                    return RedirectToAction(nameof(Index));

                return View(exam);
            }
            return View(exam);
        }


        public async Task<IActionResult> Delete((int, string) id)
        {
            var exam = await _examService.GetAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed((int, string) id)
        {
            var exam = await _examService.GetAsync(id);
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
