using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Models
{
    public class Employee
    {
        [Display(Name ="Employee ID")]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee Name")]
        [MaxLength(200)]
        public string EmployeeName { get; set; }
        public int EmployeeNumber { get; set; }
        [Display(Name ="Date Of Birth")]
       // [Column(TypeName = "DateOnly")]
        //[DisplayFormat(DataFormatString ="{dd-mm-yyyy:0}")]
        public DateTime DOB { get; set; }
        [Display(Name = "Hiring Date")]
        //[Column(TypeName = "DateOnly")]
        public DateTime HiringDate { get; set; }
        [Display(Name ="Gross Salary")]
        public decimal GrossSalary { get; set; }
        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
        [NotMapped]
        public string? DepartmentName { get; set; }
    }
}
