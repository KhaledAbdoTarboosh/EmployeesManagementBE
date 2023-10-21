using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class ApprovalsPhase
    {
        public ApprovalsPhase()
        {
            AssignedTasks = new HashSet<AssignedTask>();
            PhaseDecisions = new HashSet<PhaseDecision>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ApprovalTypeId { get; set; }
        public int FormId { get; set; }
        public int PhaseOrder { get; set; }
        public int? GroupId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual ApprovalType ApprovalType { get; set; } = null!;
        public virtual Form Form { get; set; } = null!;
        public virtual ICollection<AssignedTask> AssignedTasks { get; set; }
        public virtual ICollection<PhaseDecision> PhaseDecisions { get; set; }
    }
}
