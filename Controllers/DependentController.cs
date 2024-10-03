using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
 
    public class DependentController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllDepend()
        {
            List<Dependent> dependents = context.Dependents.Include(s => s.employee).ToList();
            return View(dependents);
        }

        public IActionResult DependAddForm()
        {
            List<Employee> dependents = context.Employees.ToList();
            ViewBag.depend = dependents;
            return View();
        }

        public IActionResult SaveDependData(string name, string essn,string sex, string date,string relation)
        {
            Dependent depend = new Dependent()
            {

                Name = name,
                ESSN=essn,
                Sex =sex,
                Date=date ,
                Relation =relation ,

            };
            context.Dependents.Add(depend);
            context.SaveChanges();
            return RedirectToAction("GetAllDepend");
        }
    }
}
