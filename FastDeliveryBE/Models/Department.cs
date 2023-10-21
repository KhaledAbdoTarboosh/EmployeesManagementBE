using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentsApprovalLevelDepartments = new HashSet<DepartmentsApprovalLevel>();
            DepartmentsApprovalLevelManagerDepartments = new HashSet<DepartmentsApprovalLevel>();
        }

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
        public virtual ICollection<DepartmentsApprovalLevel> DepartmentsApprovalLevelDepartments { get; set; }
        public virtual ICollection<DepartmentsApprovalLevel> DepartmentsApprovalLevelManagerDepartments { get; set; }
    }
}
