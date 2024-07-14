using EmployeeApiRepository.Models.Domain;
using EmployeeApiRepository.Models.DTO;
using EmployeeApiRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EmployeeApiRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GettAll()
        {
            var employeeDomain= await _employeeRepository.GetAllAsync();
            var employeeDto = new List<Employee>();

            foreach(var employee in employeeDomain)
            {
                employeeDto.Add(new Employee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Designation = employee.Designation,
                    DOB=employee.DOB,
                    IsPermanent=employee.IsPermanent,
                    Salary=employee.Salary,
                    ImageURL=employee.ImageURL
                }) ;

            }
            return Ok(employeeDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeDomain = await _employeeRepository.GetByIdAsync(id);
            if (employeeDomain == null)
            {
                return NotFound();
            }
            var employeeDto = new EmployeeDTO
            {
                Id = employeeDomain.Id,
                Name = employeeDomain.Name,
                Designation = employeeDomain.Designation,
                DOB = employeeDomain.DOB,
                IsPermanent = employeeDomain.IsPermanent,
                Salary = employeeDomain.Salary,
                ImageURL = employeeDomain.ImageURL
            };
            return Ok(employeeDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var employeeDomainModel = new Employee 
            { 
                Name = employee.Name,
                Designation = employee.Designation,
                DOB = employee.DOB,
                IsPermanent = employee.IsPermanent,
                Salary = employee.Salary,
                ImageURL = employee.ImageURL

            };
            //here populadet id than we send caller
             employeeDomainModel= await _employeeRepository.CreateAsync(employeeDomainModel);
            var employeeDto = new EmployeeDTO
            {
                Id = employeeDomainModel.Id,
                Name = employeeDomainModel.Name,
                Designation = employeeDomainModel.Designation,
                DOB = employeeDomainModel.DOB,
                IsPermanent = employeeDomainModel.IsPermanent,
                Salary = employeeDomainModel.Salary,
                ImageURL = employeeDomainModel.ImageURL
            };
            return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);

        }
        [HttpPut("{id}")]   
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            var employeeDomainModel = new Employee
            {
                Name = employee.Name,
                Designation = employee.Designation,
                DOB = employee.DOB,
                IsPermanent = employee.IsPermanent,
                Salary = employee.Salary,
                ImageURL = employee.ImageURL

            };
            employeeDomainModel = await _employeeRepository.UpdateAsync(id,employee);
            if (employeeDomainModel == null)
            {
                return NotFound();
            }
            var employeeDto = new EmployeeDTO
            {
                Id = employeeDomainModel.Id,
                Name = employeeDomainModel.Name,
                Designation = employeeDomainModel.Designation,
                DOB = employeeDomainModel.DOB,
                IsPermanent = employeeDomainModel.IsPermanent,
                Salary = employeeDomainModel.Salary,
                ImageURL = employeeDomainModel.ImageURL
            };
            return Ok(employeeDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var employeeDomainModel = await _employeeRepository.DeleteAsync(id);
            if (employeeDomainModel == null)
            {
                return NotFound();
            }
            var employeeDto = new EmployeeDTO
            {
                Id = employeeDomainModel.Id,
                Name = employeeDomainModel.Name,
                Designation = employeeDomainModel.Designation,
                DOB = employeeDomainModel.DOB,
                IsPermanent = employeeDomainModel.IsPermanent,
                Salary = employeeDomainModel.Salary,
                ImageURL = employeeDomainModel.ImageURL
            };
            return Ok(employeeDto);

        }
    }
}
