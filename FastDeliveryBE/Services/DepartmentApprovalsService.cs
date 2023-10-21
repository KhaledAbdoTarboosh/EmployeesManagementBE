using FastDeliveryBE.DTOs.DepartmentApprovals;
using FastDeliveryBE.Repositories.Approvals;
using System.Collections;

namespace FastDeliveryBE.Services
{
    public class DepartmentApprovalsService
    {

        IDepartmentApprovals departmentApprovalsRepo;
        private readonly IMapper _mapper;

        public DepartmentApprovalsService(IDepartmentApprovals departmentApprovalsRepo, IMapper mapper)
        {
            this.departmentApprovalsRepo = departmentApprovalsRepo;
            this._mapper = mapper;
        }

        public async Task AddDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            DepartmentsApprovalLevel depApproval = this._mapper.Map<DepartmentsApprovalLevel>(item);
            await departmentApprovalsRepo.AddDepartmentApprovalLevel(depApproval);
        }

        public async Task DeleteDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            DepartmentsApprovalLevel depApproval = this._mapper.Map<DepartmentsApprovalLevel>(item);
            await departmentApprovalsRepo.DeleteDepartmentApprovalLevel(depApproval);
        }

        public async  Task UpdateDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            DepartmentsApprovalLevel depApproval = this._mapper.Map<DepartmentsApprovalLevel>(item);
            await departmentApprovalsRepo.UpdateDepartmentApprovalLevel(depApproval);
        }


        public async Task<ArrayList> GetDepartmentManagerAndHisDelegates(Guid? operationID, int departmentID)
        {
            return await departmentApprovalsRepo.GetDepartmentManagerAndHisDelegates(operationID, departmentID);
        }


        public async Task<List<DepartmentsApprovalLevelInfo>> GetDepartmentsApprovalLevelsGetAll(SearchDeprtmentApprovalDTO dto)
        {

            List<DepartmentsApprovalLevel> depApprovals =await departmentApprovalsRepo.GetDepartmentsApprovalLevelsGetAll(dto);
            List<DepartmentsApprovalLevelInfo> departmentApprovals = this._mapper.Map<List<DepartmentsApprovalLevelInfo>>(depApprovals);
            return departmentApprovals;
        }
    }
}
