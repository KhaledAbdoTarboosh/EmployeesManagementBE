using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class RequestElement
    {
        public RequestElement()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public Guid RequestId { get; set; }
        public int FormElementId { get; set; }
        public string Value { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public virtual FormElement FormElement { get; set; } = null!;
        public virtual Request Request { get; set; } = null!;
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
