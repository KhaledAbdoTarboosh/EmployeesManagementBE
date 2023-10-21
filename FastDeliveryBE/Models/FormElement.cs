using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class FormElement
    {
        public FormElement()
        {
            RequestElements = new HashSet<RequestElement>();
        }

        public int Id { get; set; }
        public int FormId { get; set; }
        public string Title { get; set; } = null!;
        public int ElementTypeId { get; set; }
        public int ElementOwnerId { get; set; }
        public bool HasSource { get; set; }
        public int? SourceId { get; set; }
        public int? ExternalSourceId { get; set; }
        public bool IsMandatory { get; set; }

        public virtual ElementsType ElementType { get; set; } = null!;
        public virtual Form Form { get; set; } = null!;
        public virtual DataSource? Source { get; set; }
        public virtual ICollection<RequestElement> RequestElements { get; set; }
    }
}
