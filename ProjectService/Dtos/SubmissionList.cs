namespace ProjectService.Dtos
{
    public class SubmissionList
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? CreatorId { get; set; }
        
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
