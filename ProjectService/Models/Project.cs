namespace ProjectService.Models
{
    public class Project: BaseEntity
    {
        public string? Name { get; set; }

        public string? Duration { get; set; }

        public string? Progress { get; set; }

        public string? CreatorId { get; set; }

        public bool? isOrg { get; set; }

        public string? Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<ProjectForm>? ProjectForms { get; set; }

        public ICollection<EmployeeProjectAssociation>? ProjectAssociations { get; set; }
    }
}
