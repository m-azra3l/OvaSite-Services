namespace ProjectService.Dtos
{
    public class FormDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? CreatorId { get; set; }

        public string? FormData { get; set; }

        public int ProjectId { get; set; }
    }
}
