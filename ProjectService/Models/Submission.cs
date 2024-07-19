using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class Submission: BaseEntity
    {
        public string? Title { get; set; }

        public string? SubmissionData { get; set; }

        public string? CreatorId { get; set; }

        [ForeignKey("ProjectForm")]
        public int FormId { get; set; }

        public ProjectForm? ProjectForm { get; set; }

        public ICollection<Report>? Reports { get; set; }
    }
}
