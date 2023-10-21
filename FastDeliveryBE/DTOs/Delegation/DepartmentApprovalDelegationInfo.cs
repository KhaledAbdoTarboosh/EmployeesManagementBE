namespace FastDeliveryBE.DTOs.Delegation
{
    public class DepartmentsApprovalDelegationInfo
    {
        public int DepartmentsApprovalDelegationId { get; set; }

        public Guid? DelegatorUserId { get; set; }

        public Guid DelegatedUserId { get; set; }

        public int? DelegatorDepartmentId { get; set; }

        public int? ForDepartmentId { get; set; }

        public Guid? OperationId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
