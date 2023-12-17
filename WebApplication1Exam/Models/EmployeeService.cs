using Microsoft.EntityFrameworkCore;

namespace WebApplication1Exam.Models
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; }
        Employee? Get(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);



    }
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDb db;

        public EmployeeService(EmployeeDb employeeDb)
        {
            this.db = employeeDb;
        }


        public List<Employee> Employees
        {
            get {
                return db.Employees.ToList();
            }
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public Employee? Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Update(Employee employee)
        {
            db.Entry<Employee>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
