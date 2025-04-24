using ExamSysttem.Models;
using ExamSysttem.Services.Interfaces;
using ExamSysttem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamSysttem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IActionResult> Index(int examId)
        {
            var questions = await _questionService.GetAllForAdminAsync(examId);
            return View(questions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCreate question)
        {
            if (ModelState.IsValid)
            {
                await _questionService.CreateAsync(question);
                return RedirectToAction(nameof(Index), new { examId = question.ExamId });
            }
            return View(question);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var question = await _questionService.GetByIdForAdminAsync(id);
            if (question == null) return NotFound();
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id,QuestionCreate question)
        {
            if (ModelState.IsValid)
            {
                await _questionService.UpdateAsync(Id,question);
                return RedirectToAction(nameof(Index), new { examId = question.ExamId });
            }
            return View(question);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var question = await _questionService.GetByIdForAdminAsync(id);
            if (question == null) return NotFound();
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _questionService.GetByIdForAdminAsync(id);
            if (question == null) return NotFound();

            await _questionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { examId = question.Exam.Id });
        }
    }
}
