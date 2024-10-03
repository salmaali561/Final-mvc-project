using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;
using MVC_Task2.View_Model;
using System.Runtime.Intrinsics.X86;

namespace MVC_Task2.Controllers
{

    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()
        {
            return View();
        }
        #region Employee
        public IActionResult GetAll()
        {
            List<Employee> employees = context.Employees.OrderBy(e => e.SSN).ToList();
            return View(employees);
        }

        public IActionResult GetById(string Emp_id)
        {

            Employee emp = context.Employees.SingleOrDefault(s => s.SSN == Emp_id);

            return View("Details", emp);
        }
        #endregion
        #region Delete
        public IActionResult Delete(string id)
        {
            Employee std = context.Employees.SingleOrDefault(s => s.SSN == id);
            context.Employees.Remove(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        #endregion

        #region Update
        public IActionResult EmpEditForm(string id)
        {
            Employee employee = context.Employees.SingleOrDefault(s => s.SSN == id);
            //    List<Department> departments = context.Departments.ToList();
            //    List<Employee > employees  = context.Employees.ToList();
            //    ViewBag.depts = departments;
            //return View(employee);

            List<Employee> employees = context.Employees.ToList();
            List<Department> departments = context.Departments.ToList();
            EmpVM empVM = new EmpVM();
            empVM.Employees = employees;
            empVM.Departments = departments;
            ViewBag.depts = empVM;
            return View(employee);

        }
        public IActionResult SaveEmployeeEdit(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return RedirectToAction("GetAll");

        }
        #endregion
        #region Add

        public IActionResult EmpAddForm()
        {
            List<Employee> employee = context.Employees.ToList();
            List<Department> departments = context.Departments.ToList();
            EmpVM empVM = new EmpVM();
            empVM.Employees = employee;
            empVM.Departments = departments;
            ViewBag.emp=empVM;
            return View();
        }

        public IActionResult SaveFormDataEmp(Employee employee)
        {

            //old Add Function//
            //context.Employees.Add(employee);
            //context.SaveChanges();
            //return RedirectToAction("GetAll");
            if (ModelState.IsValid == true)
            {

                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Getall");
            }
            else
            {
                List<Employee> employees = context.Employees.ToList();
                List<Department> departments = context.Departments.ToList();
                EmpVM empVM = new EmpVM();
                empVM.Employees = employees;
                empVM.Departments = departments;
                ViewBag.emp = empVM;
                return View("EmpAddForm");
            }
        }
        #endregion

       



    }
}
