namespace ProjectService.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? CreatorId { get; set; }

        public string? ReportData { get; set; }

        public string? Status { get; set; }

        public int SubmissionId { get; set; }
    }
}
