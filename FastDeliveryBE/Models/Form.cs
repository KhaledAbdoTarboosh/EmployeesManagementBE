using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Form
    {
        public Form()
        {
            ApprovalsPhases = new HashSet<ApprovalsPhase>();
            FormElements = new HashSet<FormElement>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<ApprovalsPhase> ApprovalsPhases { get; set; }
        public virtual ICollection<FormElement> FormElements { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
