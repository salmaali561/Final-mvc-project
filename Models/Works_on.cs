using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Works_on
    {
        [ForeignKey("employee")]
        public string ESSN { set; get; }
        [ForeignKey("project")]
        public string Pnum { set; get; }
        public virtual Employee employee { set; get; }
        public virtual Project project { set; get; }
        public string hour { set; get; }
    }
}
