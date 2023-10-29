using AutoMapper;
using FastDeliveryBE.DTOs;
using FastDeliveryBE.DTOs.Delegation;
using FastDeliveryBE.DTOs.DepartmentApprovals;
using FastDeliveryBE.DTOs.Services;
using FastDeliveryBE.DTOs.Users;
using FastDeliveryBE.Models;

namespace FastDeliveryBE.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Department, DepartmentInfo>().ReverseMap();
            CreateMap<DepartmentsType, DepartmentTypeInfo>().ReverseMap();
            CreateMap<User, UserInfo>().ReverseMap();
            CreateMap<DepartmentsApprovalDelegation, DepartmentsApprovalDelegationInfo>().ReverseMap();
            CreateMap<DepartmentsApprovalLevel, DepartmentsApprovalLevelInfo>().ReverseMap();
            CreateMap<Service, ServiceInfo>().ReverseMap();

        }
    }
}
