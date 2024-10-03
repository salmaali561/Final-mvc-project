using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Dependent
    {
        [Key]
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Date { get; set; }
        public string Relation { get; set; }
        #region Employee
        [ForeignKey("employee")]
        public string? ESSN { set; get; }
        public virtual Employee? employee { set; get; }
        #endregion
    }
}
