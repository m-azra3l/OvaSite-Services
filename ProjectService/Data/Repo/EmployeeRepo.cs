using Microsoft.EntityFrameworkCore;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class EmployeeRepo: IEmployeeRepo
    {
        private readonly DataContext dc;
        public EmployeeRepo(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddEmployee(Employee employee)
        {
            dc.Employees.Add(employee);
        }

        public void DeleteEmployee(string empNameId)
        {
            var employee = dc.Employees.FirstOrDefault(x => x.EmpNameId == empNameId);
            if(employee != null) 
                dc.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empNameId)
        {
            var employee = await dc.Employees.FirstOrDefaultAsync(x => x.EmpNameId == empNameId);

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await dc.Employees.ToListAsync();

            return employees;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesbyOrgAsync(string orgNameId)
        {
            var employees = await dc.Employees.Where(p => p.OrgNameId == orgNameId).ToListAsync();

            return employees;
        }
    }
}
