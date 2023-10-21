using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class ApprovalType
    {
        public ApprovalType()
        {
            ApprovalsPhases = new HashSet<ApprovalsPhase>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<ApprovalsPhase> ApprovalsPhases { get; set; }
    }
}
