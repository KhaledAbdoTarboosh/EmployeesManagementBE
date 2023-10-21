using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class PhaseDecision
    {
        public int Id { get; set; }
        public int PhaseId { get; set; }
        public int DecisionId { get; set; }
        public bool IsClosure { get; set; }

        public virtual DecisionsType Decision { get; set; } = null!;
        public virtual ApprovalsPhase Phase { get; set; } = null!;
    }
}
