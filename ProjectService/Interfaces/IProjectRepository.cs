using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();

        Task<IEnumerable<Project>> GetProjectsAsync(string orgNameId);

        Task<Project> GetProjectByDetailAsync(int id);

        Task<Project> GetProjectByIdAsync(int id);

        void AddProject(Project project);

        void DeleteProject(int id);
    }
}
