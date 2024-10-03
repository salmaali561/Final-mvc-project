using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public string  SSN { set; get; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Name can't be more than 20")]
        public string FName { set; get; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Name can't be more than 20 ")]
        public string LName { set; get; }

        [Required]
        [MinLength(2, ErrorMessage = "time must be 2 character only")]
        [MaxLength(2, ErrorMessage = "time must be 2 character only")]
        public string Minit { set; get; }

        [Required(ErrorMessage = "This field is required")]
        public string BDate { set; get; }
        [MinLength(5, ErrorMessage = "Address must be 5 Charcters at least")]
        [MaxLength(50, ErrorMessage = "Address can be 50 Charcters at most")]
        public string Address { set; get; }
        [Required]
        public string Sex { set; get; }
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName ="money")]
        public decimal  Salary { set; get; }

        #region Self Relation
        [InverseProperty("Supervisor")]
        public virtual List<Employee>? group { set; get; }
        [ForeignKey("Supervisor")]
        public string? superSSN { set; get; }
        public virtual Employee? Supervisor { set; get; }
        #endregion

        #region Works_on
        public virtual List<Works_on >? works { set; get; }
        #endregion

        #region Department
        [ForeignKey("Dept")]
        public long? Dnum { set; get; }
        public virtual Department? Dept { get; set; }
        #endregion

        #region Dependent
        public virtual List<Dependent>? dependent { set; get; }

        public static implicit operator Employee(List<Employee> v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
