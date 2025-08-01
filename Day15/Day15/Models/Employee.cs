using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Day15.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [ValidateNever]
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
