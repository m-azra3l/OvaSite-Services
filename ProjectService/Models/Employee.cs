
using System.ComponentModel.DataAnnotations;

namespace ProjectService.Models
{
    public class Employee: BaseEntity
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? EmpNameId { get; set; }

        [Required]
        public string? Email { get; set; }

        public ICollection<EmployeeProjectAssociation>? ProjectAssociations { get; set; }
    }
}
