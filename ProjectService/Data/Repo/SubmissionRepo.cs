using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using ProjectService.Interfaces;
using ProjectService.Models;

namespace ProjectService.Data.Repo
{
    public class SubmissionRepo: ISubmissionRepo
    {
        private readonly DataContext dc;

        public SubmissionRepo(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Submission>> GetAllSubmissionsAsync()
        {
            var submissions = await dc.Submissions.ToListAsync();
            return submissions;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsAsync(int formId)
        {
            var submissions = await dc.Submissions
                 .Where(p => p.FormId == formId)
                 .ToListAsync();

            return submissions;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsbyUserAsync(string creatorId, int formId)
        {
            var submissions = await dc.Submissions
                 .Where(p => p.CreatorId == creatorId && p.FormId == formId)
                 .ToListAsync();

            return submissions;
        }

        public async Task<Submission> GetSubmissionDetailAsync(int id)
        {
            var submission = await dc.Submissions
                .Include(p => p.ProjectForm)
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return submission;
        }

        public async Task<Submission> GetSubmissionbyIdAsync(int id)
        {
            var submission = await dc.Submissions
                .Include(p => p.ProjectForm)
                 .Where(p => p.Id == id)
                 .FirstAsync();

            return submission;
        }

        public void AddSubmmission(Submission submission)
        {
            dc.Submissions.Add(submission);
        }

        public void DeleteSubmission(int id)
        {
            var submission = dc.Submissions.Find(id);
            if (submission != null) dc.Submissions.Remove(submission);
        }
    }
}
