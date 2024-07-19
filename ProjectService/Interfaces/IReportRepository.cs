using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReportsAync();

        Task<IEnumerable<Report>> GetAllReportsAync(int submissionId);

        Task<IEnumerable<Report>> GetUserReportsAync(string creatorId, int submissionId);

        Task<Report> GetReportDetailAsync(int id);

        Task<Report> GetReportbyIdAsync(int id);

        void AddReport(Report report);

        void DeleteReport(int id);
    }
}
