using ProjectService.Interfaces;
using ProjectService.Data.Repo;

namespace ProjectService.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IEmployeeRepo EmployeeRepo => new EmployeeRepo(dc);

        public IEmpProjectRepo EmpProjectRepo => new EmpProjectRepo(dc);

        public IFormRepository FormRepository => new FormRepository(dc);

        public IProjectRepository ProjectRepository => new ProjectRepository(dc);

        public IReportRepository ReportRepository => new ReportRepository(dc);

        public ISubmissionRepo SubmissionRepo => new SubmissionRepo(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
