using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Dept_Locations
    {
        [ForeignKey("department")]
        public long? Dnum { set; get; }
        public virtual Department? department { get; set; }
        public string locations { set; get; }
    }
}
