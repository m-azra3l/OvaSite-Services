using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Dtos;
using ProjectService.Models;
using ProjectService.Interfaces;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ProjectController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await uow.ProjectRepository.GetAllAsync();
            var projectList = mapper.Map<IEnumerable<ProjectList>>(projects);
            return Ok(projectList);
        }

        [HttpGet("list/{orgNameId}")]
        public async Task<IActionResult> GetOrgProjects(string orgNameId)
        {
            var projects = await uow.ProjectRepository.GetProjectsAsync(orgNameId);
            var projectList = mapper.Map<IEnumerable<ProjectList>>(projects);
            return Ok(projectList);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProject(ProjectDto projectDto)
        {
            var project = mapper.Map<Project>(projectDto);
            project.CreatedDate = DateTime.Now;
            uow.ProjectRepository.AddProject(project);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}/{nameid}")]
        public async Task<IActionResult> UpdateProject(int id, string nameid, ProjectDto projectDto)
        {

            if (id != projectDto.Id)
                return BadRequest("Update not allowed");

            var projectFromDb = await uow.ProjectRepository.GetProjectByIdAsync(id);

            if(projectFromDb.isOrg == true)
            {
                if (projectFromDb.OrgNameId != nameid)
                    return BadRequest("You are not authorized to update this project");
            }
            else
            {
                if (projectFromDb.CreatorId != nameid)
                    return BadRequest("You are not authorized to update this project");
            }

            if (projectFromDb == null)
                return BadRequest("Update not allowed");
            projectFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(projectDto, projectFromDb);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete-project/{projectid}/{creatorId}")]
        public async Task<IActionResult> DeleteProject(int projectid, string creatorid)
        {
            var project = await uow.ProjectRepository.GetProjectByIdAsync(projectid);

            if (project == null)
                return BadRequest("No such project exists");

            if (project.CreatorId != creatorid)
                return BadRequest("You are not authorized to delete this project");

            uow.ProjectRepository.DeleteProject(projectid);
            await uow.SaveAsync();
            return Ok(projectid);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetProjectDetail(int id)
        {
            var project = await uow.ProjectRepository.GetProjectByDetailAsync(id);
            var projectDTO = mapper.Map<ProjectDetail>(project);
            return Ok(projectDTO);
        }

        [HttpGet("list-employee-associated/{projectId}")]
        public async Task<IActionResult> GetProjectEmployees(int projectId)
        {
            var employees = await uow.EmpProjectRepo.GetProjectEmployees(projectId);
            var employeeList = mapper.Map<IEnumerable<ProjectEmployeeList>>(employees);
            return Ok(employeeList);
        }

        [HttpGet("list-project-associated/{empNameId}")]
        public async Task<IActionResult> GetEmployeeProjects(string empNameId)
        {
            var projects = await uow.EmpProjectRepo.GetProjectsByUserAsync(empNameId);
            var projectList = mapper.Map<IEnumerable<EmployeeProjectList>>(projects);
            return Ok(projectList);
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee(ProjAssociationDto associationDto)
        {
            var projectAssociation = mapper.Map<EmployeeProjectAssociation>(associationDto);
            projectAssociation.CreatedDate = DateTime.Now;
            projectAssociation.LastUpdatedOn = DateTime.Now;
            uow.EmpProjectRepo.AddEmpProject(projectAssociation);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update-employee-role/{empNameId}")]
        public async Task<IActionResult> UpdateEmployeeRole(string empNameId, ProjAssociationDto associationDto)
        {
            if(empNameId != associationDto.EmpNameId) return BadRequest("No such project employee");

            var projAssociation = await uow.EmpProjectRepo.GetUserByIdAsync(empNameId);
            projAssociation.LastUpdatedOn = DateTime.Now;
            mapper.Map(associationDto, projAssociation);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("remove-employee/{empNameId}")]
        public async Task<IActionResult> RemoveEmployee(string empNameId)
        {
            var employee = await uow.EmpProjectRepo.GetUserByIdAsync(empNameId);

            if (employee == null) return BadRequest("No such project employee");

            uow.EmpProjectRepo.RemoveEmpProject(empNameId);
            await uow.SaveAsync();
            return Ok(empNameId);
        }
    }
}
