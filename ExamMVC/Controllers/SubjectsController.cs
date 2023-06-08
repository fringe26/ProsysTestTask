using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainModels.Models.ExamModel;
using Repository.DAL;
using Repository.Repositories.Implementation;
using Services.ExamService.Abstractions;

namespace ExamMVC.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _subjectService.GetAllAsync());
        }

        [HttpGet("[controller]/[action]/{key}")]
        public async Task<IActionResult> Details(string key)
        {
            if (key == null || _subjectService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetAsync(key);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectCode,SubjectName,Class,TeacherFirstName,TeacherLastName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _subjectService.CreateAsync(subject);
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        [HttpGet("[controller]/[action]/{key}")]
        public async Task<IActionResult> Edit(string key)
        {
            if (key == null || _subjectService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetAsync(key);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubjectCode,SubjectName,Class,TeacherFirstName,TeacherLastName")] Subject subject)
        {
            if (id != subject.SubjectCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _subjectService.UpdateAsync(subject);
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        [HttpGet("[controller]/[action]/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            if (key == null || _subjectService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetAsync(key);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_subjectService.GetAllAsync() == null)
            {
                return Problem("Entity set 'ExamDbContext.Subjects'  is null.");
            }
            var subject = await _subjectService.GetAsync(id);
            if (subject != null)
            {
                await _subjectService.DeleteAsync(subject);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
