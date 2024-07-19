using ProjectService.Models;

namespace ProjectService.Dtos
{
    public class ProjectDetail: ProjectList
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<ProjectForm>? ProjectForms { get; set; }

        public ICollection<EmployeeProjectAssociation>? ProjectAssociations { get; set; }
    }
}
