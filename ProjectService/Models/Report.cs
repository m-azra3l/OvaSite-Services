using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class Report: BaseEntity
    {
        public string? Title { get; set; }

        public string? ReportData { get; set; }

        public string? CreatorId { get; set; }

        public string? Status { get; set; }

        [ForeignKey("ProjectForm")]
        public int SubmissionId { get; set; }

        public Submission? Submission { get; set; }
    }
}
