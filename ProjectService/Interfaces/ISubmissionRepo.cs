using ProjectService.Models;

namespace ProjectService.Interfaces
{
    public interface ISubmissionRepo
    {

        Task<IEnumerable<Submission>> GetAllSubmissionsAsync();

        Task<IEnumerable<Submission>> GetSubmissionsAsync(int formId);

        Task<IEnumerable<Submission>> GetSubmissionsbyUserAsync(string creatorId, int formId);

        Task<Submission> GetSubmissionDetailAsync(int id);

        Task<Submission> GetSubmissionbyIdAsync(int id);

        void AddSubmmission(Submission submission);

        void DeleteSubmission(int id);
    }
}
