using EmployeeApiRepository.Models.Domain;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Runtime.InteropServices;

namespace EmployeeApiRepository.Repository
{
    public interface IEmployeeRepository
    {
       Task<List<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);
        Task<Employee>CreateAsync(Employee employee);
        Task<Employee?> UpdateAsync(int id, Employee employee);
        Task<Employee?> DeleteAsync(int id);

    }
}
