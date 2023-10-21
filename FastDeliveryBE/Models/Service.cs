using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Service
    {
        public Service()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FormId { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Form Form { get; set; } = null!;
        public virtual ICollection<Request> Requests { get; set; }
    }
}
