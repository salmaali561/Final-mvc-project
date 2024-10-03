using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Department
    {
        [Key]
        public long DNumber { set; get; }
        public string DName { set; get; }
        public string MgrDate { set; get; }
        #region Employee
        //relation 1-->1
        [ForeignKey("employee")]
        public string? mgrSSN { set; get; }
        public virtual Employee? employee { get; set; }
        //relation 1-->many
        [InverseProperty("Dept")]
        public virtual List<Employee> employees { set; get; }
        #endregion
        #region locations
        public virtual List<Dept_Locations> Locations { set; get; }
        #endregion
        #region project
        public virtual List<Project> project { set; get; }
        #endregion
    }
}
