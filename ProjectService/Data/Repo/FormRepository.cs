using Microsoft.EntityFrameworkCore;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class FormRepository: IFormRepository
    {
        private readonly DataContext dc;

        public FormRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<ProjectForm>> GetAllFormsAsync()
        {
            var forms = await dc.ProjectForms.ToListAsync();
            return forms;
        }

        public async Task<IEnumerable<ProjectForm>> GetProjectFormsAsync(int projectId)
        {
            var forms = await dc.ProjectForms.Include(p => p.Submissions)
                 .Include(p => p.Reports)
                 .Where(p => p.ProjectId == projectId)
                 .ToListAsync();

            return forms;
        }

        public async Task<IEnumerable<ProjectForm>> GetFormsByUserAsync(string creatorId, int projectId)
        {
            var forms = await dc.ProjectForms
                 .Where(p => p.CreatorId == creatorId && p.ProjectId == projectId)
                 .ToListAsync();

            return forms;
        }

        public async Task<ProjectForm> GetFormByDetailAsync(int id)
        {
            var form = await dc.ProjectForms.Include(p => p.Submissions)
                 .Include(p => p.Reports)
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return form;
        }

        public async Task<ProjectForm> GetFormByIdAsync(int id)
        {
            var form = await dc.ProjectForms.Include(p => p.Submissions)
                 .Include(p => p.Reports)
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return form;
        }

        public void AddForm(ProjectForm projectForm)
        {
            dc.ProjectForms.Add(projectForm);
        }

        public void DeleteForm(int id)
        {
            var projectForm = dc.ProjectForms.Find(id);
            if (projectForm != null) 
                dc.ProjectForms.Remove(projectForm);
        }
    }
}
