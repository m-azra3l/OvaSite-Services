using System.Linq;
using AutoMapper;
using ProjectService.Dtos;
using ProjectService.Models;

namespace ProjectService.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        { 
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<EmployeeProjectAssociation, ProjAssociationDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<ProjectForm, FormDto>().ReverseMap();

            CreateMap<Report, ReportDto>().ReverseMap();

            CreateMap<Submission, SubmissionDto>().ReverseMap();

            CreateMap<EmployeeProjectAssociation, EmployeeProjectList>()
                .ForMember(d => d.Project, opt => opt.MapFrom(src => src.Project.Name));

            CreateMap<EmployeeProjectAssociation, ProjectEmployeeList>()
                .ForMember(d => d.Employee, opt => opt.MapFrom(src => src.Employee.EmpNameId));

            CreateMap<Project, ProjectDetail>();

            CreateMap<Project, ProjectList>();

            CreateMap<Report, ReportDetail>()
                .ForMember(d => d.Submission, opt => opt.MapFrom(src => src.Submission.Title));

            CreateMap<Report, ReportList>()
                .ForMember(d => d.Submission, opt => opt.MapFrom(src => src.Submission.Title));


            CreateMap<Submission, SubmissionDetail>()
                .ForMember(d => d.ProjectForm, opt => opt.MapFrom(src => src.ProjectForm.Title));

            CreateMap<Submission, SubmissionList>();
        }
    }
}
