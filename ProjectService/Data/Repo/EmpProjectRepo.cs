using Microsoft.EntityFrameworkCore;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class EmpProjectRepo: IEmpProjectRepo
    {
        private readonly DataContext dc;

        public EmpProjectRepo(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<EmployeeProjectAssociation>> GetProjectsByUserAsync(string empNameId)
        {
            var projAssociation = await dc.ProjectAssociations
                .Include(p => p.Project)
                .Include(p => p.Employee)
                .Where(p => p.EmpNameId == empNameId)
                .ToListAsync();
            return projAssociation;
        }

        public async Task<IEnumerable<EmployeeProjectAssociation>> GetProjectEmployees(int projectId)
        {
            var projAssociation = await dc.ProjectAssociations
                .Include(p => p.Project)
                .Include(p => p.Employee)
                .Where(p => p.ProjectId == projectId)
                .ToListAsync();
            return projAssociation;
        }

        public async Task<EmployeeProjectAssociation> GetUserByIdAsync(string empNameId)
        {
            var projAssociation = await dc.ProjectAssociations.FirstOrDefaultAsync(x => x.EmpNameId == empNameId);
            return projAssociation;
        }

        public void AddEmpProject(EmployeeProjectAssociation empProjectAssociation)
        {
            dc.ProjectAssociations.Add(empProjectAssociation);
        }

        public void RemoveEmpProject(string empNameId)
        {
            var projAssociation = dc.ProjectAssociations.FirstOrDefault(p => p.EmpNameId == empNameId);
            if (projAssociation != null) dc.ProjectAssociations.Remove(projAssociation);
        }
    }
}
