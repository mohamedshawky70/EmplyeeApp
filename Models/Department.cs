using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Department
    {
        [Display(Name ="Department ID")]
        public int DepartmentID { get; set; }
        [MaxLength(200)]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set;}
        [Display(Name ="Abbreviation")]
        [MaxLength(10)]
        public string DepartmentAbbr { get; set;}
        public List<Employee> employees { get; set; }


    }
}
