

using Microsoft.EntityFrameworkCore;

namespace WebApplication1Exam.Models
{
    public class EmployeeDb:DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }


        public EmployeeDb(DbContextOptions opt):base(opt)
        {
            
        }
    }
}
