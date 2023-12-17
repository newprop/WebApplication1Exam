using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1Exam.Models
{
    [Table("EmployeeTable")]
   
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Column("EmpName")]
        public string EmployeeName { get; set; }
        [Required]
        
        public Designation Designation { get; set; }
        
        public DateOnly JoinDate { get; set; }

        public decimal Salary { get; set; }
        public bool IsPermanent { get; set; }

        public string? ImageUrl { get; set; }


        public List<Experience> Experiences { get; set; } = new List<Experience>();


    }


    public enum Designation
    {
        GeneralManager,
        Asst_Manager,
        Officer,
        Office_Asst,
        Accountant

    }


    [Table("ExperienceTable")]
    public class Experience
    {
        [Key]
        public int ExpID { get; set; }

        public Designation Designation { get; set; }
        [Required]
        public string Company { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode =true)]
        public decimal Salary { get; set; }
    }
}
