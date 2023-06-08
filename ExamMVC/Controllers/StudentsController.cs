using DomainModels.Models.ExamModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.ExamService.Abstractions;

namespace ExamMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService service)
        {
            _studentService = service;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
              return View(await _studentService.GetAllAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _studentService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentNumber,FirstName,LastName,Class")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _studentService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentNumber,FirstName,LastName,Class")] Student student)
        {
            if (id != student.StudentNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
           
               await  _studentService.UpdateAsync(student);
                
          
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _studentService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_studentService.GetAllAsync() == null)
            {
                return Problem("Entity set 'ExamDbContext.Students'  is null.");
            }
            var student = await _studentService.GetAsync(id);
            if (student != null)
            {
                await _studentService.DeleteAsync(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
