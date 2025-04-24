using ExamSysttem.Data;
using ExamSysttem.Models;
using ExamSysttem.Services.Interfaces;
using ExamSysttem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamSysttem.Controllers
{
    // ExamController.cs
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {
            var exams = await _examService.GetAllAsync();
            return View(exams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamCreate model)
        {
            if (ModelState.IsValid)
            {
                await _examService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exam = await _examService.GetByIdAsync(id);
            if (exam == null) return NotFound();

            var model = new ExamEdit
            {
                Id = exam.Id,
                Name = exam.Name,
                Description = exam.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExamEdit model)
        {
            if (ModelState.IsValid)
            {
                await _examService.UpdateAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exam = await _examService.GetByIdAsync(id);
            if (exam == null) return NotFound();
            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var exam = await _examService.GetByIdAsync(id);
            if (exam == null) return NotFound();
            return RedirectToAction("Index", "Question", new { examId = id });
        }

    }
}
