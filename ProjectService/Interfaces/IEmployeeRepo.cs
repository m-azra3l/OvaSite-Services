using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<IEnumerable<Employee>> GetEmployeesbyOrgAsync(string orgNameId);

        Task<Employee> GetEmployeeByIdAsync(string empNameId);

        void AddEmployee(Employee employee);

        void DeleteEmployee(string empNameId);
    }
}
