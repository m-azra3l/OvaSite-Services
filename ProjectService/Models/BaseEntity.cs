using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        
        public string? OrgNameId { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    }
}
