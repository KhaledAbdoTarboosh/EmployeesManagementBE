using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
