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
		public async Task<IActionResult> Delete(int id)
		{
			var studentToDelete = await _context.Students.FindAsync(id);
			if (studentToDelete != null) 
			{
				_context.Students.Remove(studentToDelete);
				await _context.SaveChangesAsync();
			}
				return RedirectToAction("Index");
			
		}
	}
}
