using Microsoft.EntityFrameworkCore;
using Sample_API.Data.Entities;
using System.Reflection;

namespace Sample_API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
