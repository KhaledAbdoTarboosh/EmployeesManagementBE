using FastDeliveryBE.DTOs.Delegation;
using FastDeliveryBE.Repositories.Delegations;

namespace FastDeliveryBE.Services
{
    public class DelegationsService
    {

        IDepartmentsApprovalDelegations delegationRepo;
        private readonly IMapper _mapper;

        public DelegationsService(DepartmentsApprovalDelegations delegationRepo, IMapper mapper)
        {
            this.delegationRepo = delegationRepo;
            this._mapper = mapper;
        }


        public async Task AddDepartmentsApprovalDelegation(DepartmentsApprovalDelegationInfo item)
        {
            DepartmentsApprovalDelegation delegation = this._mapper.Map<DepartmentsApprovalDelegation>(item);

            await delegationRepo.AddDepartmentsApprovalDelegation(delegation);
        }


        public async Task DeleteDepartmentsApprovalDelegation(DepartmentsApprovalDelegationInfo item)
        {
            DepartmentsApprovalDelegation delegation = this._mapper.Map<DepartmentsApprovalDelegation>(item);

            await delegationRepo.DeleteDepartmentsApprovalDelegation(delegation);
        }


        public async Task DeleteUserApprovalDelegation(Guid DelegatedUserId)
        {
            await delegationRepo.DeleteUserApprovalDelegation(DelegatedUserId);
        }

        public async Task<List<DepartmentsApprovalDelegationInfo>> SearchDepartmentsApprovalDelegations
            (SearchDepartmentsApprovalDelegationDTO dto)
        {
            List<DepartmentsApprovalDelegation> items = await delegationRepo.SearchDepartmentsApprovalDelegations(dto);
            List<DepartmentsApprovalDelegationInfo> delegations = this._mapper.Map<List<DepartmentsApprovalDelegationInfo>>(items);

            return delegations;
        }
    }
}
