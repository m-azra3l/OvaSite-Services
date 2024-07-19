using Microsoft.EntityFrameworkCore;
using ProjectService.Models;

namespace ProjectService.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id = 1, 
                    Username = "username1", 
                    EmpNameId = "emp1", 
                    OrgNameId = "org1", 
                    Description = "No description", 
                    Email = "test@mail.com", 
                    CreatedDate = DateTime.Now, 
                    LastUpdatedOn = DateTime.Now},
                new Employee
                {
                    Id = 2,
                    Username = "username2",
                    EmpNameId = "emp2",
                    OrgNameId = "org1",
                    Description = "No description",
                    Email = "test@mail.com",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });

            modelBuilder.Entity<Project>().HasData(
                new Project { 
                    Id = 1, 
                    Name = "Project1", 
                    Duration= "12 Months",
                    Progress = "6 months",
                    isOrg = true,
                    CreatorId = "user1",
                    Status = "In progres",
                    StartDate = DateTime.Now,
                    OrgNameId = "org1",
                    Description = "Project 1 started",
                    CreatedDate= DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new Project { 
                    Id = 2, 
                    Name = "Project2",
                    Duration = "12 Months",
                    Progress = "6 months",
                    isOrg = false,
                    CreatorId = "user1",
                    Status = "In progres",
                    StartDate = DateTime.Now,
                    OrgNameId = null,
                    Description = "Project 1 started",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });

            modelBuilder.Entity<EmployeeProjectAssociation>().HasData(
                new EmployeeProjectAssociation { 
                    Id = 1,
                    EmployeeId = 1,
                    EmpNameId = "emp1", 
                    ProjectId = 1,
                    OrgNameId = "org1",
                    Role = "Project Manager",
                    Description = "The project manager",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new EmployeeProjectAssociation { 
                    Id = 2,
                    EmployeeId = 2,
                    EmpNameId = "emp2", 
                    ProjectId = 1, 
                    OrgNameId = "org1",
                    Role = "Supervisor",
                    Description = "The project manager",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });

            modelBuilder.Entity<ProjectForm>().HasData(
                new ProjectForm { 
                    Id = 1, 
                    Title = "Form1", 
                    ProjectId = 1, 
                    OrgNameId = "org1",
                    CreatorId = "user1",
                    Description = "Form 1",
                    FormData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new ProjectForm { 
                    Id = 2, 
                    Title = "Form2", 
                    ProjectId = 2,
                    OrgNameId = null,
                    CreatorId = "user1",
                    Description = "Form 2",
                    FormData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });

            modelBuilder.Entity<Report>().HasData(
                new Report { 
                    Id = 1, 
                    Title = "Report1", 
                    SubmissionId = 1,
                    OrgNameId = "org1",
                    CreatorId = "user1",
                    Description = "Report 1",
                    ReportData = "my report",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new Report { 
                    Id = 2, 
                    Title = "Report2", 
                    SubmissionId = 2,
                    OrgNameId = null,
                    CreatorId = "user1",
                    Description = "report 2",
                    ReportData = "my report",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });

            modelBuilder.Entity<Submission>().HasData(
                new Submission { 
                    Id = 1, 
                    Title = "Submission1", 
                    FormId = 1,
                    OrgNameId = "org1",
                    CreatorId = "user1",
                    Description = "Submission 1",
                    SubmissionData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new Submission { 
                    Id = 2, 
                    Title = "Submission2", 
                    FormId = 2,
                    OrgNameId = null,
                    CreatorId = "user1",
                    Description = "Submission 2",
                    SubmissionData = "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}",
                    CreatedDate = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                });
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeProjectAssociation> ProjectAssociations { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectForm> ProjectForms { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Submission> Submissions { get; set; }
    }
}
