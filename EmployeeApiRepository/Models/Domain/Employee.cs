using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EmployeeApiRepository.Models.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        public DateOnly DOB { get; set; }

        public bool IsPermanent { get; set; }
        public double Salary { get; set; }

        public string ImageURL { get; set; }
    }
}
