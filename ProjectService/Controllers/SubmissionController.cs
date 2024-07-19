using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Dtos;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SubmissionController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list-submissions")]
        public async Task<IActionResult> GetAll()
        {
            var submissions = await uow.SubmissionRepo.GetAllSubmissionsAsync();
            var submissionsList = mapper.Map<IEnumerable<SubmissionList>>(submissions);
            return Ok(submissionsList);
        }

        [HttpGet("list-form-submissions/{formId}")]
        public async Task<IActionResult> GetFormSubmissions(int formId)
        {
            var submissions = await uow.SubmissionRepo.GetSubmissionsAsync(formId);
            var submissionsList = mapper.Map<IEnumerable<SubmissionList>>(submissions);
            return Ok(submissionsList);
        }

        [HttpGet("list-user-submissions/{formId}/{creatorId}")]
        public async Task<IActionResult> GetSubmissionsByUser(string creatorId, int formId)
        {
            var submissions = await uow.SubmissionRepo.GetSubmissionsbyUserAsync(creatorId, formId);
            var submissionsList = mapper.Map<IEnumerable<SubmissionList>>(submissions);
            return Ok(submissionsList);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubmission(SubmissionDto submissionDto)
        {
            var submission = mapper.Map<Submission>(submissionDto);
            submission.CreatedDate = DateTime.Now;
            uow.SubmissionRepo.AddSubmmission(submission);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update-submission/{id}/{creatorId}")]
        public async Task<IActionResult> UpdaateSubmission(int id, string creatorId, SubmissionDto submissionDto)
        {
            if (id != submissionDto.Id)
                return BadRequest("Update not allowed");

            var subFromDb = await uow.SubmissionRepo.GetSubmissionbyIdAsync(id);

            if (subFromDb.CreatorId != creatorId)
                return BadRequest("You are not authorized to update this submission");

            if (subFromDb == null)
                return BadRequest("Update not allowed");
            subFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(submissionDto, subFromDb);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete-submission/{id}/{creatorId}")]
        public async Task<IActionResult> DeleteSubmission(int id, string creatorId)
        {
            var submission = await uow.SubmissionRepo.GetSubmissionbyIdAsync(id);

            if (submission == null) return BadRequest("No such submission exists");

            if (submission.CreatorId != creatorId)
                return BadRequest("You are not authorized to delete this submission");

            uow.SubmissionRepo.DeleteSubmission(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpGet("view-submission/{id}")]
        public async Task<IActionResult> ViewSubmission(int id)
        {
            var submission = await uow.SubmissionRepo.GetSubmissionDetailAsync(id);
            var submissionDto = mapper.Map<SubmissionDetail>(submission);
            return Ok(submissionDto);
        }
    }
}
