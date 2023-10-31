using AutoMapper;


using EmployeesManagementBE.DTOs.Attachments;
using EmployeesManagementBE.DTOs.Employees;

namespace EmployeesManagementBE.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Department, DepartmentInfo>().ReverseMap();
            CreateMap<Skill, SkillInfo>().ReverseMap();
            CreateMap<Employee, EmployeeInfo>().ReverseMap();
            CreateMap<Experience, ExperienceInfo>().ReverseMap();
            CreateMap<Certification, CertificationInfo>().ReverseMap();
            CreateMap<Attachment, AttachmentInfo>().ReverseMap();
            CreateMap<AttachmentType, AttachmentTypeInfo>().ReverseMap();

        }
    }
}
