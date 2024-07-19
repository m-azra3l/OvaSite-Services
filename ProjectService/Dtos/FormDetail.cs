using ProjectService.Models;

namespace ProjectService.Dtos
{
    public class FormDetail
    {
        public string? Name { get; set; }

        public string? CreatorId { get; set; }

        public string? FormData { get; set; }

        public string? Project { get; set; }

        public ICollection<Submission>? Submissions { get; set; }
    }
}
