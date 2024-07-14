namespace EmployeeApiRepository.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public DateOnly DOB { get; set; }

        public bool IsPermanent { get; set; }
        public double Salary { get; set; }
        public string ImageURL { get; set; }
    }
}
