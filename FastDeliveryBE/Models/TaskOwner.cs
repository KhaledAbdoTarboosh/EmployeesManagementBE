using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class TaskOwner
    {
        public int Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
    }
}
