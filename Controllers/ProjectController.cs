using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class ProjectController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()
        {
            return View();
        }
        #region Project get all and  by ID
        public IActionResult GetAllProject()
        {
            List<Project> projects = context.Projects.Include(s => s.department).ToList();
            return View(projects);
        }
        public IActionResult GetById_Project(string Pnum)
        {

            Project PNum = context.Projects.Include(s => s.department).SingleOrDefault(s => s.PNum == Pnum);

            return View("Info", PNum);
        }
        #endregion
        #region Project Delete
        public IActionResult Delete(string id)
        {
            Project project = context.Projects.SingleOrDefault(s => s.PNum == id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("GetAllProject");
        }
        #endregion

        #region Edit
        public IActionResult ProjectAddForm()
        {
            List<Department> departments = context.Departments.ToList();
            ViewBag.depts = departments;
            return View();
        }
        public IActionResult SaveFormDataproject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("GetAllProject");
        }

       public IActionResult ProjectEditForm(string id)
        {
            Project project = context.Projects.SingleOrDefault(s=>s.PNum==id);
            List<Department> departments = context.Departments.ToList();
            ViewBag.depts = departments;
            return View(project);
        }
        public IActionResult SaveProjectEdit(Project project)
        {
                context.Projects.Update(project);
                context.SaveChanges();
                return RedirectToAction("GetAllProject");
            
        }

        //    public IActionResult SaveProjectData(Project project)
        //{
        //    if (ModelState.IsValid == true)
        //    {

        //        context.Projects.Add(project);
        //        context.SaveChanges();
        //        return RedirectToAction("GetAllProject");
        //    }
        //    else
        //    {
        //        List<Department> departments = context.Departments.ToList();
        //        ViewBag.project = departments;
        //        return View("ProjectEditForm");
        //    }
        //}

        //public IActionResult ProjectEditForm(string id)
        //{
        //    Project project = context.Projects.SingleOrDefault(s => s.PNum == id);
        //    List<Department> departments = context.Departments.ToList();
        //    ViewBag.project = departments;
        //    return View(project);
        //}

        //public IActionResult SaveEditProjectData(Project project)
        //{
        //    context.Projects.Update(project);
        //    context.SaveChanges();
        //    return RedirectToAction("GetAllProject");
        //}
        #endregion
    }
}
