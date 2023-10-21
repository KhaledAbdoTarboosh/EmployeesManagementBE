using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class ElementsType
    {
        public ElementsType()
        {
            FormElements = new HashSet<FormElement>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;

        public virtual ICollection<FormElement> FormElements { get; set; }
    }
}
