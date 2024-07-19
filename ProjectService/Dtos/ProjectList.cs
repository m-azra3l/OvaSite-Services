namespace ProjectService.Dtos
{
    public class ProjectList
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Duration { get; set; }

        public string? Progress { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
