using ProjectService.Models;

namespace ProjectService.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? OrgNameId { get; set; }

        public string? CreatorId { get; set; }

        public string? Duration { get; set; }

        public string? Progress { get; set; }

        public string? Status { get; set; }

        public bool? isOrg { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}
