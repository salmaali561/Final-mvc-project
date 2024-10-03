using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Project
    {
        [Key]
        public string PNum { set; get; }
        public string PName { set; get; }
        public string Plocation { set; get; }
        public virtual List<Works_on> work { set; get; }
        #region Departments
        [ForeignKey("department")]
        public long? Dnum { set; get; }
        public virtual Department? department { set; get; }
        #endregion
    }
}
