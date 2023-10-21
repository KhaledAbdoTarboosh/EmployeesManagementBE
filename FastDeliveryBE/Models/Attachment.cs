using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class Attachment
    {
        public Guid AttachmentId { get; set; }
        public int RequestElementId { get; set; }
        public string Path { get; set; } = null!;
        public string Extension { get; set; } = null!;

        public virtual RequestElement RequestElement { get; set; } = null!;
    }
}
