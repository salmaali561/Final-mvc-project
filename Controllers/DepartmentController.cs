using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()
        {
            return View();
        }
        #region Department
        public IActionResult GetAllDepart()
        {
            List<Department> departments = context.Departments.Include(s => s.employee).ToList();
            return View(departments);
        }
        /////////////
        public IActionResult GetById_Dept(long DNum)
        {

            Department DNumber = context.Departments.Include(s => s.employee).SingleOrDefault(s => s.DNumber == DNum);

            return View("Data", DNumber);
        }

        public IActionResult DeptAddForm()
        {
            List<Employee> departments = context.Employees.ToList();
            ViewBag.dept = departments;
            return View();
        }

        public IActionResult SaveFormData(string dname, string mgrdate, string mgrssn)
        {
            Department dept = new Department()
            {
                
                DName = dname,
                MgrDate = mgrdate,
                mgrSSN=mgrssn
               
            };
            context.Departments.Add(dept);
            context.SaveChanges();
            return RedirectToAction("GetAllDepart");
        }
        #endregion
        public IActionResult Delete(long id)
        {
            Department  dept = context.Departments.SingleOrDefault(s => s.DNumber == id);
            context.Departments.Remove(dept);
            context.SaveChanges();
            return RedirectToAction("GetAllDepart");
        }

        public IActionResult DepartmentEditForm(long id)
        {
            Department? department  = context.Departments.SingleOrDefault(s => s.DNumber == id);
            List<Employee> employees  = context.Employees.ToList();
            ViewBag.Employees = employees;
            return View(department);
        }
        public IActionResult SaveDepartmentEdit(Department department)
        {
            context.Departments.Update(department);
            context.SaveChanges();
            return RedirectToAction("GetAllDepart");

        }

    }
}
