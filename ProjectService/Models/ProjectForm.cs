using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class ProjectForm: BaseEntity
    {
        public string? Title { get; set; }

        public string? FormData { get; set; }

        public string? CreatorId { get; set; }

        public ICollection<Report>? Reports { get; set; }   

        public ICollection<Submission>? Submissions { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
