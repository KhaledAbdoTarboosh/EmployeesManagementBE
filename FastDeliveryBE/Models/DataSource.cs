using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DataSource
    {
        public DataSource()
        {
            DataSourceItems = new HashSet<DataSourceItem>();
            FormElements = new HashSet<FormElement>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<DataSourceItem> DataSourceItems { get; set; }
        public virtual ICollection<FormElement> FormElements { get; set; }
    }
}
