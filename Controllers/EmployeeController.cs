using EmployeeApp.Date;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context ;
        public EmployeeController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult GetAllEmployee()
        {
            //List<Employee> employees = context.employees.ToList();
            var employees = from emp in context.employees
                            join
                            dept in context.departments
                            on emp.DepartmentID equals dept.DepartmentID
                            select new Employee()
                            {
                                EmployeeID = emp.EmployeeID,
                                EmployeeName = emp.EmployeeName,
                                EmployeeNumber = emp.EmployeeNumber,
                                DOB = emp.DOB,
                                GrossSalary = emp.GrossSalary,
                                HiringDate = emp.HiringDate,
                                NetSalary=emp.NetSalary,
                                DepartmentName = dept.DepartmentName
                            };
            return View("GetAllEmployee",employees);
        }
        public IActionResult Edite(int id)
        {
            if (id == null) BadRequest();
            Employee employee = context.employees.SingleOrDefault(i=>i.EmployeeID==id);
            if (employee == null) return NotFound();
            ViewBag.dept = context.departments.ToList();
            return View("Create",employee);
        }
        [HttpPost]
        public IActionResult Edite(Employee NewEmployee)
        {
            ModelState.Remove("department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                context.employees.Update(NewEmployee);
                context.SaveChanges();
                return RedirectToAction(nameof(GetAllEmployee));
            }
            ViewBag.dept = context.departments.ToList();
            return View("Create", NewEmployee);
        }
        public IActionResult Create()
        {
            ViewBag.dept = context.departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ModelState.Remove("department");

            if (ModelState.IsValid)
            {
                context.Add(employee);
                context.SaveChanges();
                return RedirectToAction("GetAllEmployee");
            }
            ViewBag.dept = context.departments.ToList();
            return View();
        }
        public IActionResult Delete(int id)
        {
            Employee employee = context.employees.SingleOrDefault(i => i.EmployeeID == id);
            context.employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("GetAllEmployee");
        }
        
        public IActionResult Sort()
        {
            var employees = (from emp in context.employees
                            join
                            dept in context.departments
                            on emp.DepartmentID equals dept.DepartmentID
                            select new Employee()
                            {
                                EmployeeID = emp.EmployeeID,
                                EmployeeName = emp.EmployeeName,
                                EmployeeNumber = emp.EmployeeNumber,
                                DOB = emp.DOB,
                                GrossSalary = emp.GrossSalary,
                                HiringDate = emp.HiringDate,
                                NetSalary = emp.NetSalary,
                                DepartmentName = dept.DepartmentName
                            }).OrderByDescending(i=>i.GrossSalary).ToList();
            return View("GetAllEmployee", employees);
        }
        public IActionResult Search(string Name)
        {
            var employee = context.employees.SingleOrDefault(i => i.EmployeeName == Name);
            return View("GetAllEmployee", employee);
             
        }
    }
}
