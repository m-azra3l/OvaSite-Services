namespace ProjectService.Dtos
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? CreatorId { get; set; }

        public string? SubmissionData { get; set; }

        public int FormId { get; set; }
    }
}
