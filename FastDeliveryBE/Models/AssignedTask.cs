using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class AssignedTask
    {
        public Guid TaskId { get; set; }
        public Guid RequestId { get; set; }
        public int PhaseId { get; set; }
        public int? DecisionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDone { get; set; }
        public string? Notes { get; set; }
        public DateTime? ExecutedOn { get; set; }
        public Guid? ExecutedBy { get; set; }
        public DateTime? TimeOutOn { get; set; }

        public virtual ApprovalsPhase Phase { get; set; } = null!;
        public virtual Request Request { get; set; } = null!;
    }
}
