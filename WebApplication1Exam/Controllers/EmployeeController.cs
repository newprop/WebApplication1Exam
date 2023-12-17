using Microsoft.AspNetCore.Mvc;
using WebApplication1Exam.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1Exam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }



        public IActionResult Index()
        {
            var data = employeeService.Employees;
            return View(data);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return BadRequest("id is null");
            }

            int empid = id ?? 0;

            var data = employeeService.Get(empid);
            if (data is null)
            {
                return BadRequest("employee n ot found by id = " + id);
            }


            return View(data);
        }
        [HttpGet]

        public IActionResult Create()
        {
            EmployeeViewModel model= new EmployeeViewModel();

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel emp, [FromServices] IWebHostEnvironment environment, string operation="")
        {
            if(emp.ImageUpload != null)
            {
                TempData["ImageUpload"] = emp.ImageUpload;
            }
            else if(TempData["ImageUpload"] != null)
            {
                emp.ImageUpload =  TempData["ImageUpload"] as IFormFile;
            }

            if (operation=="add")
            {
                emp.Experiences.Add(new ());
                return View(emp);
            }

            if (operation.Contains("delete"))
            {
                int index = Convert.ToInt32(operation.Replace("delete-", string.Empty));

                emp.Experiences.RemoveAt(index);
                return View(emp);
            }

            if (ModelState.IsValid)
            {
                if(emp.ImageUpload != null)
                {
                    string path =  $"\\Images\\{emp.ImageUpload.FileName}";

                    string filePath = environment.WebRootPath + path;

                    using FileStream fileStream = new FileStream(filePath, FileMode.Create);


                    emp.ImageUpload.CopyTo(fileStream);

                    emp.ImageUrl = path;
                }

                employeeService.Create(emp.ToEmployee());

                return RedirectToAction("index");


            }
            return View(emp);
        }
    }
}
