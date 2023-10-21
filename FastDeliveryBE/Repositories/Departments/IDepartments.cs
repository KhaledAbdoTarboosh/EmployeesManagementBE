using FastDeliveryBE.DTOs;
using FastDeliveryBE.Models;

namespace FastDeliveryBE.Repositories.Departments
{
    public interface IDepartments
    {
        Task<Department?> GetDepartmentByID(int departmentID);

        Task AddDepartment(Department department);

        Task UpdateDepartment(Department department);

        Task<List<Department>> GetDepartmentsTree(List<Department> result, int parentDepartmentID);

        Task<List<Department>> GetDepartmentParents(List<Department> result, int DepartmentID);

        Task<List<DepartmentEmployeesCountInfo>> GetChildDepartmentEmployeesCount(int DepartmentID);

        Task<List<Department>> GetDepartmentsByIds(List<int> depIDs);

        Task<List<DepartmentManagerInfo>> GetDepartmentsManagrsUserIDsByDepartmentsIDs(List<int> depIDs);

        Task<List<Department>> GetDepartmentsByManagerUserID(Guid managerUserID);

        Task DeleteDepartment(int departmentID);

        Task<List<Department>> GetOSDepartments();

        Task<List<Department>> GetDepartmentsByTypeIds(List<int> depTypesIds);

        Task<DepartmentsType> GetDepartmentType(int departmentID);

        Task SetDepartmentManager(int departmentID, Guid userID);


    }
}
