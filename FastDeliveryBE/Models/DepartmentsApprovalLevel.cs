using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DepartmentsApprovalLevel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int LevelOfApproval { get; set; }
        public bool ForManager { get; set; }
        public int ManagerDepartmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Department ManagerDepartment { get; set; } = null!;
    }
}
