using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface IFormRepository
    {
        Task<IEnumerable<ProjectForm>> GetAllFormsAsync();

        Task<IEnumerable<ProjectForm>> GetProjectFormsAsync(int projectId);

        Task<IEnumerable<ProjectForm>> GetFormsByUserAsync(string creatorId, int projectId);

        Task<ProjectForm> GetFormByDetailAsync(int id);

        Task<ProjectForm> GetFormByIdAsync(int id);

        void AddForm(ProjectForm projectForm);

        void DeleteForm(int id);
    }
}
