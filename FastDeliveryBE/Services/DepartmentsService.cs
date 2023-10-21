using FastDeliveryBE.DTOs;
using FastDeliveryBE.Models;
using FastDeliveryBE.Repositories.Departments;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace FastDeliveryBE.Application.Departments
{
    public class DepartmentsService
    {
        IDepartments departmentsRepo;
        private readonly IMapper _mapper;

        public DepartmentsService(IDepartments departmentRepo, IMapper mapper)
        {
            this.departmentsRepo = departmentRepo;
            this._mapper = mapper;
        }

        public async Task<DepartmentInfo> GetDepartmentByID(int departmentID)
        {
            Department? dep = await departmentsRepo.GetDepartmentByID(departmentID);

            if (dep == null) return new DepartmentInfo();

            DepartmentInfo departmentInfo = this._mapper.Map<DepartmentInfo>(dep);

            return departmentInfo;
        }

        public async Task<List<DepartmentInfo>> GetDepartmentsTree(List<Department> result, int parentDepartmentID)
        {
            List<Department> deps = await departmentsRepo.GetDepartmentsTree(result, parentDepartmentID);

            List<DepartmentInfo> departments = this._mapper.Map<List<DepartmentInfo>>(deps);

            return departments;
        }

        public async Task<List<DepartmentInfo>> GetDepartmentParents(List<Department> result, int departmentID)
        {
            List<Department> deps = await departmentsRepo.GetDepartmentParents(result, departmentID);

            List<DepartmentInfo> departments = this._mapper.Map<List<DepartmentInfo>>(deps);

            return departments;
        }

        public async Task<List<DepartmentEmployeesCountInfo>> GetChildDepartmentEmployeesCount(int departmentID)
        {
            return await departmentsRepo.GetChildDepartmentEmployeesCount(departmentID);

        }

        public async Task<List<DepartmentInfo>> GetDepartmentsByIds(List<int> depIDs)
        {
            List<Department> deps = await departmentsRepo.GetDepartmentsByIds(depIDs);

            List<DepartmentInfo> departments = this._mapper.Map<List<DepartmentInfo>>(deps);

            return departments;

        }

        public async Task<List<DepartmentManagerInfo>> GetDepartmentsManagrsUserIDsByDepartmentsIDs(List<int> depIDs)
        {
            return await departmentsRepo.GetDepartmentsManagrsUserIDsByDepartmentsIDs(depIDs);

        }

        public async Task<List<Department>> GetDepartmentsByManagerUserID(Guid managerUserID)
        {
            return await departmentsRepo.GetDepartmentsByManagerUserID(managerUserID);
        }

        public async Task AddDepartment(DepartmentInfo department)
        {
            Department dep = this._mapper.Map<Department>(department);
            await departmentsRepo.AddDepartment(dep);
        }

        public async Task UpdateDepartment(DepartmentInfo department)
        {
            Department dep = this._mapper.Map<Department>(department);
            await departmentsRepo.UpdateDepartment(dep);
        }

        public async Task DeleteDepartment(int departmentID)
        {
            await departmentsRepo.DeleteDepartment(departmentID);
        }

        public async Task<List<DepartmentInfo>> GetOSDepartments()
        {
            List<Department> deps = await departmentsRepo.GetOSDepartments();
            List<DepartmentInfo> departments = this._mapper.Map<List<DepartmentInfo>>(deps);
            return departments;
        }

        public async Task<List<DepartmentInfo>> GetDepartmentsByTypeIds(List<int> depTypesIds)
        {
            List<Department> deps = await departmentsRepo.GetDepartmentsByTypeIds(depTypesIds);
            List<DepartmentInfo> departments = this._mapper.Map<List<DepartmentInfo>>(deps);
            return departments;
        }

        public async Task<DepartmentTypeInfo> GetDepartmentType(int departmentID)
        {

            DepartmentsType depsType = await departmentsRepo.GetDepartmentType(departmentID);
            DepartmentTypeInfo departmentType = this._mapper.Map<DepartmentTypeInfo>(depsType);
            return departmentType;
        }

        public async Task SetDepartmentManager(int departmentID, Guid userID)
        {

            await departmentsRepo.SetDepartmentManager(departmentID, userID);
        }

    }
}
