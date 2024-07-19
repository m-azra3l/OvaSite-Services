using Microsoft.EntityFrameworkCore;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class ReportRepository: IReportRepository
    {
        private readonly DataContext dc;

        public ReportRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Report>> GetReportsAync()
        {
            var reports = await dc.Reports
                 .ToListAsync();

            return reports;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAync(int submissionId)
        {
            var reports = await dc.Reports
                 .Where(p => p.SubmissionId == submissionId)
                 .ToListAsync();

            return reports;
        }

        public async Task<IEnumerable<Report>> GetUserReportsAync(string creatorId, int submissionId)
        {
            var reports = await dc.Reports
                  .Where(p => p.CreatorId == creatorId && p.SubmissionId == submissionId)
                  .ToListAsync();

            return reports;
        }

        public async Task<Report> GetReportDetailAsync(int id)
        {
            var report = await dc.Reports
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return report;
        }

        public async Task<Report> GetReportbyIdAsync(int id)
        {
            var report = await dc.Reports
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return report;
        }

        public void AddReport(Report report)
        {
            dc.Reports.Add(report);
        }

        public void DeleteReport(int id)
        {
            var report = dc.Reports.Find(id);
            if (report != null) dc.Reports.Remove(report);
        }
    }
}
