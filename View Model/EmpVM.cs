using MVC_Task2.Models;

namespace MVC_Task2.View_Model
{
    public class EmpVM
    {

        
        public List<Department> Departments { get; set; }
        public List<Employee> Supervisors { get; set; }
        public List<Employee> Employees { get; internal set; }
    }
}
