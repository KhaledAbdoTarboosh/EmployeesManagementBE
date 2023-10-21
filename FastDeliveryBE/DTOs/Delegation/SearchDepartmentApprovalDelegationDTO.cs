namespace FastDeliveryBE.DTOs.Delegation
{
    public class SearchDepartmentsApprovalDelegationDTO
    {
        public int? delegatorDepartmentID { get; set; }

        public Guid? DelegatedUserId { get; set; }

        public Guid? operationID { get; set; }
    }
}
