using ProjectService.Models;

namespace ProjectService.Dtos
{
    public class SubmissionDetail: SubmissionList
    {
        public string? SubmissionData { get; set; }

        public string? ProjectForm { get; set; }

        public ICollection<Report>? Reports { get; set; }
    }
}
