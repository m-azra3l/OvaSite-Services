using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface IEmpProjectRepo
    {
        Task<IEnumerable<EmployeeProjectAssociation>> GetProjectsByUserAsync(string empNameId);

        Task<IEnumerable<EmployeeProjectAssociation>> GetProjectEmployees(int projectId);

        Task<EmployeeProjectAssociation> GetUserByIdAsync(string empNameId);

        void AddEmpProject(EmployeeProjectAssociation empProjectAssociation);

        void RemoveEmpProject(string empNameId);
    }
}
