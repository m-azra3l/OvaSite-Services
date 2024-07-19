namespace ProjectService.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepo EmployeeRepo { get; }
        
        IEmpProjectRepo EmpProjectRepo { get; }

        IFormRepository FormRepository { get; }

        IProjectRepository ProjectRepository { get; }

        IReportRepository ReportRepository { get; }

        ISubmissionRepo SubmissionRepo { get; }

        Task<bool> SaveAsync();
    }
}
