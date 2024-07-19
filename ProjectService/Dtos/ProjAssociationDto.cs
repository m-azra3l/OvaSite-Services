using ProjectService.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Dtos
{
    public class ProjAssociationDto
    {
        public int EmployeeId { get; set; }

        public string? EmpNameId { get; set; }

        public int ProjectId { get; set; }

        public string? Role { get; set; }
    }
}
