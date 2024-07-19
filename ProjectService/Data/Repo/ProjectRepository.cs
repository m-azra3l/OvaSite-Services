using Microsoft.EntityFrameworkCore;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DataContext dc;

        public ProjectRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddProject(Project project)
        {
            dc.Projects.Add(project);
        }

        public void DeleteProject(int id)
        {
            var project = dc.Projects.Find(id);
            if (project != null) 
                dc.Projects.Remove(project);
        }

        public async Task<IEnumerable<Project>> GetAllAsync() 
        {
            var projects = await dc.Projects.ToListAsync();

            return projects;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(string orgNameId)
        {
            var properties = await dc.Projects.Include(p => p.ProjectForms)
                .Include(p => p.ProjectAssociations)
                .Where(p => p.OrgNameId == orgNameId)
                .ToListAsync();

            return properties;
        }

        public async Task<Project> GetProjectByDetailAsync(int id)
        {
            var property = await dc.Projects.Include(p => p.ProjectForms)
                .Include(p => p.ProjectAssociations)
                .Where(p => p.Id == id)
                .FirstAsync();

            return property;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var property = await dc.Projects.Include(p => p.ProjectForms)
                .Include(p => p.ProjectAssociations)
                .Where(p => p.Id == id)
                .FirstAsync();

            return property;
        }
    }
}
