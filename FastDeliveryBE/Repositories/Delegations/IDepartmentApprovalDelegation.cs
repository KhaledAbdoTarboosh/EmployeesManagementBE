using FastDeliveryBE.DTOs.Delegation;

namespace FastDeliveryBE.Repositories.Delegations
{
    public interface IDepartmentsApprovalDelegations
    {
        Task AddDepartmentsApprovalDelegation(DepartmentsApprovalDelegation item);

        Task DeleteDepartmentsApprovalDelegation(DepartmentsApprovalDelegation item);

        Task DeleteUserApprovalDelegation(Guid DelegatedUserId);

        Task<List<DepartmentsApprovalDelegation>> SearchDepartmentsApprovalDelegations
            (SearchDepartmentsApprovalDelegationDTO dto);

        Task<List<DepartmentsApprovalDelegation>> GetAllDepartmentsApprovalDelegationsByManagerUserIDAndOperationID
            (Guid userId, Guid? operationID);


    }
}
