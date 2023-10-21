namespace FastDeliveryBE.DTOs.DepartmentApprovals
{
    public class DepartmentsApprovalLevelInfo
    {

        public int DepartmentApprovalLevelId { get; set; }

        public Guid? OperationId { get; set; }

        public int DepartmentId { get; set; }

        public byte LevelOfApproval { get; set; }

        public bool ForManager { get; set; }

        public int? ManagerDepartmentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual DepartmentInfo Department { get; set; } = null!;

        public virtual DepartmentInfo? ManagerDepartment { get; set; }
    }
}
