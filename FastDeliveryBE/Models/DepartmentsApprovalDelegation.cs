using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DepartmentsApprovalDelegation
    {
        public int Id { get; set; }
        public Guid DelegatedUserId { get; set; }
        public int DelegatorDepartmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
