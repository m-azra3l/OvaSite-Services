using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Dtos;
using ProjectService.Models;
using ProjectService.Interfaces;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public FormController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list-forms")]
        public async Task<IActionResult> GetAll()
        {
            var forms = await uow.FormRepository.GetAllFormsAsync();
            var formList = mapper.Map<IEnumerable<FormList>>(forms);
            return Ok(formList);
        }

        [HttpGet("list-project-forms/{projectId}")]
        public async Task<IActionResult> GellAllForms(int projectId)
        {
            var forms = await uow.FormRepository.GetProjectFormsAsync(projectId);
            var formList = mapper.Map<IEnumerable<FormList>>(forms);
            return Ok(formList);
        }

        [HttpGet("list-user-forms/{projectId}/{creatorId}")]
        public async Task<IActionResult> GetFormsByUser(string creatorId, int projectId)
        {
            var forms = await uow.FormRepository.GetFormsByUserAsync(creatorId, projectId);
            var formList = mapper.Map<IEnumerable<FormList>>(forms);
            return Ok(formList);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddForm(FormDto formDto)
        {
            var projectForm = mapper.Map<ProjectForm>(formDto);
            projectForm.CreatedDate = DateTime.Now;
            uow.FormRepository.AddForm(projectForm);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update-form/{formId}/{creatorId}")]
        public async Task<IActionResult> UpdateForm(string creatorId, int formId, FormDto formDto)
        {
            if (formId != formDto.Id)
                return BadRequest("Update not allowed");

            var formFromDb = await uow.FormRepository.GetFormByIdAsync(formId);

            if (formFromDb.CreatorId != creatorId)
                return BadRequest("You are not authorized to update this form");

            if (formFromDb == null)
                return BadRequest("Update not allowed");

            formFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(formDto, formFromDb);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete-form/{formId}/{creatorId}")]
        public async Task<IActionResult> DeleteForm(int formId, string creatorId)
        {
            var projectForm = await uow.FormRepository.GetFormByIdAsync(formId);

            if (projectForm == null) return BadRequest("No such form exists");

            if (projectForm.CreatorId != creatorId)
                return BadRequest("You are not authorized to delete this project");

            uow.FormRepository.DeleteForm(formId);
            await uow.SaveAsync();
            return Ok(formId);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetFormDetail(int id)
        {
            var projectForm = await uow.FormRepository.GetFormByDetailAsync(id);
            var formDTO = mapper.Map<FormDetail>(projectForm);
            return Ok(formDTO);
        }

    }
}
