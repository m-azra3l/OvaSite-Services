using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Dtos;
using ProjectService.Models;
using ProjectService.Interfaces;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public ReportController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> ListAllReports()
        {
            var reports = await uow.ReportRepository.GetReportsAync();
            var reportList = mapper.Map<IEnumerable<ReportList>>(reports);
            return Ok(reportList);
        }

        [HttpGet("list-submission-reports/{Id}")]
        public async Task<IActionResult> ListSubmissionReports(int Id)
        {
            var reports = await uow.ReportRepository.GetAllReportsAync(Id);
            var reportList = mapper.Map<IEnumerable<ReportList>>(reports);
            return Ok(reportList);
        }

        [HttpGet("list-user-reports/{Id}/{creatorId}")]
        public async Task<IActionResult> ListUserReports(string creatorId,int Id)
        {
            var reports = await uow.ReportRepository.GetUserReportsAync(creatorId, Id);
            var reportList = mapper.Map<IEnumerable<ReportList>>(reports);
            return Ok(reportList);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReport(ReportDto reportDto)
        {
            var report = mapper.Map<Report>(reportDto);
            report.CreatedDate = DateTime.Now;
            uow.ReportRepository.AddReport(report);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update-report/{id}/{creatorId}")]
        public async Task<IActionResult> UpdaateSubmission(int id, string creatorId, ReportDto reportDto)
        {
            if (id != reportDto.Id)
                return BadRequest("Update not allowed");

            var subFromDb = await uow.ReportRepository.GetReportbyIdAsync(id);

            if (subFromDb.CreatorId != creatorId)
                return BadRequest("You are not authorized to update this report");

            if (subFromDb == null)
                return BadRequest("Update not allowed");
            subFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(reportDto, subFromDb);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete-report/{id}/{creatorId}")]
        public async Task<IActionResult> DeleteReport(int id, string creatorId)
        {
            var report = await uow.ReportRepository.GetReportbyIdAsync(id);

            if (report == null) return BadRequest("No such report exists");

            if (report.CreatorId != creatorId)
                return BadRequest("You are not authorized to delete this report");

            uow.ReportRepository.DeleteReport(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpGet("view-report/{id}")]
        public async Task<IActionResult> ViewReport(int id)
        {
            var report = await uow.ReportRepository.GetReportDetailAsync(id);
            var reportDto = mapper.Map<ReportDetail>(report);
            return Ok(reportDto);
        }
    }
}
