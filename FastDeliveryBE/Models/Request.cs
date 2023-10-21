using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Request
    {
        public Request()
        {
            AssignedTasks = new HashSet<AssignedTask>();
            RequestElements = new HashSet<RequestElement>();
        }

        public Guid RequestId { get; set; }
        public Guid UserId { get; set; }
        public int ServiceId { get; set; }
        public int RequestStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public int CurrentPhaseId { get; set; }

        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<AssignedTask> AssignedTasks { get; set; }
        public virtual ICollection<RequestElement> RequestElements { get; set; }
    }
}
