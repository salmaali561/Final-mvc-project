using System.ComponentModel.DataAnnotations;

namespace MVC_Task2.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            // check in database

            string newName = value.ToString();
            CompanyContext context = new CompanyContext();
            Employee emp = context.Employees.SingleOrDefault(s => s.FName == newName);
            if (emp != null)
            {
                return new ValidationResult("this name already exist");

            }
            return ValidationResult.Success;
            return base.IsValid(value, validationContext);
        }
    }
}
