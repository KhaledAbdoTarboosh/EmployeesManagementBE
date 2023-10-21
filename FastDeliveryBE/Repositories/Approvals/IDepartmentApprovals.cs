using FastDeliveryBE.DTOs.DepartmentApprovals;
using System.Collections;

namespace FastDeliveryBE.Repositories.Approvals
{
    public interface IDepartmentApprovals
    {

        Task AddDepartmentApprovalLevel(DepartmentsApprovalLevel item);

        Task UpdateDepartmentApprovalLevel(DepartmentsApprovalLevel item);

        Task DeleteDepartmentApprovalLevel(DepartmentsApprovalLevel item);

        Task<List<DepartmentsApprovalLevel>> GetDepartmentsApprovalLevelsGetAll
            (SearchDeprtmentApprovalDTO dto);

        Task<ArrayList> GetDepartmentManagerAndHisDelegates(Guid? operationID, int departmentID);
    }
}
