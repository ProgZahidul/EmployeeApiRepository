using EmployeeApiRepository.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiRepository.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt):base(opt)
        {
            
        }
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1,Name="Hasan",Designation="Officer",DOB=DateOnly.Parse("1992-01-01"),IsPermanent=true,Salary=10000, ImageURL=""}
            );
        }
    }
}
