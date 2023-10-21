using FastDeliveryBE.DTOs.DepartmentApprovals;

namespace FastDeliveryBE.DTOs
{
    public class DepartmentInfo
    {
        public int DepartmentId { get; set; }
        public int DepartmentTypeId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? ParentDepartmentId { get; set; }
        public Guid? ManagerUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }

        public virtual DepartmentsType DepartmentType { get; set; } = null!;
        public virtual User? ManagerUser { get; set; }
        public virtual ICollection<DepartmentsApprovalLevelInfo> DepartmentsApprovalLevelDepartments { get; set; }
        public virtual ICollection<DepartmentsApprovalLevelInfo> DepartmentsApprovalLevelManagerDepartments { get; set; }
    }
}
