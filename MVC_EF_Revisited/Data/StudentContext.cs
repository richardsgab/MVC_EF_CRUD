using Microsoft.EntityFrameworkCore;
using MVC_EF_Revisited.Models;

namespace MVC_EF_Revisited.Data
{
	public class StudentContext: DbContext
	{
        public StudentContext(DbContextOptions<StudentContext> options): base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }//the table for Student in the DB
    }
}
