using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1Exam.Models
{
    public class EmployeeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Display(Name = "Employee Name")]

        public string EmployeeName { get; set; }
        [Required]

        public Designation Designation { get; set; }
        [Display(Name = "Join Date")]
        public DateOnly JoinDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Salary { get; set; }
        [Display(Name = "Permanent?")]
        public bool IsPermanent { get; set; }

        public string? ImageUrl { get; set; }
        [Display(Name = "Image Upload ")]
        public IFormFile? ImageUpload { get; set; }


        public List<Experience> Experiences { get; set; } = new List<Experience>();



        public Employee ToEmployee()
        {
            Employee e = new Employee()
            {
                ID = this.ID,
                EmployeeName = this.EmployeeName,
                Designation = this.Designation,
                JoinDate = this.JoinDate,
                IsPermanent = this.IsPermanent,
                Salary = this.Salary,
                ImageUrl = this.ImageUrl,
                Experiences = this.Experiences,
            };
            return e;
        }


    }
}
