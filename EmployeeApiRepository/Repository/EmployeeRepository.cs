using EmployeeApiRepository.DAL;
using EmployeeApiRepository.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EmployeeApiRepository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
           await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var existingEmployee = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmployee == null)
            {
                return null;

            }
             _context.employees.Remove(existingEmployee);

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
         return await   _context.employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee?> UpdateAsync(int id, Employee employee)
        {
           var existEmployee= await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existEmployee == null)
            {
                return null;
            }
            existEmployee.Name = employee.Name;
            existEmployee.Designation = employee.Designation;
            existEmployee.DOB = employee.DOB;
            existEmployee.IsPermanent = employee.IsPermanent;
            existEmployee.Salary = employee.Salary;
            existEmployee.ImageURL = employee.ImageURL;
            await _context.SaveChangesAsync();
            return existEmployee;
        }
    }
}
