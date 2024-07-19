using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class EmployeeProjectAssociation: BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string? EmpNameId { get; set; }

        public Employee? Employee { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        public string? Role { get; set; }
    }
}
