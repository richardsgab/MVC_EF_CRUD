using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Revisited.Data;
using MVC_EF_Revisited.Models;

namespace MVC_EF_Revisited.Controllers
{
	public class StudentController : Controller
	{
		private readonly StudentContext _context;
		public StudentController(StudentContext context)//this is dependency injection
		{
			_context = context;
		}
		
		public async Task<IActionResult> Index()//async await!
		{
			var students = await _context.Students.ToListAsync();
			return View(students);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Student student)
		{
			if (ModelState.IsValid) 
			{
				_context.Students.Add(student);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);
			return View(student);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var student = await _context.Students.FindAsync(id);
			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
