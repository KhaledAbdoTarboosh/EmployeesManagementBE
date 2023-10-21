using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DecisionsType
    {
        public DecisionsType()
        {
            PhaseDecisions = new HashSet<PhaseDecision>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<PhaseDecision> PhaseDecisions { get; set; }
    }
}
