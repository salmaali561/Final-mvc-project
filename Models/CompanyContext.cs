using Microsoft.EntityFrameworkCore;

namespace MVC_Task2.Models
{
    public class CompanyContext:DbContext 
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Works_on > Works { get; set; }
        public DbSet<Dept_Locations> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-DIFGR19\\SQLEXPRESS;Database=CompanyContext;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Works_on>().HasKey("ESSN", "Pnum");
            modelBuilder.Entity<Dept_Locations>().HasKey("Dnum", "locations");
            modelBuilder.Entity<Dependent>().HasKey("Name", "ESSN");
            base.OnModelCreating(modelBuilder);
        }
    }
}
