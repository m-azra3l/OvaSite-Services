using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Dtos;
using ProjectService.Models;
using ProjectService.Interfaces;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        
        public EmployeeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list-employees/{orgnameId}")]
        public async Task<IActionResult> ListEmployees(string orgnameId)
        {
            var employees = await uow.EmployeeRepo.GetEmployeesbyOrgAsync(orgnameId);
            var employeeList = mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeList);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            employee.LastUpdatedOn = DateTime.Now;
            uow.EmployeeRepo.AddEmployee(employee);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete-employee/{orgnameid}/{empnameid}")]
        public async Task<IActionResult> DeleteEmployee( string orgnameid, string empnameid)
        { 
            var employee = await uow.EmployeeRepo.GetEmployeeByIdAsync(empnameid);

            if(employee == null)
                return BadRequest("No such employee exists");

            if (employee.OrgNameId != orgnameid)
                return BadRequest("You are not authorized to delete this employee");

            uow.EmployeeRepo.DeleteEmployee(empnameid);
            await uow.SaveAsync();
            return Ok(empnameid);
        }
    }
}
