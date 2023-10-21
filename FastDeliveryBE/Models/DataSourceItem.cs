using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DataSourceItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ArName { get; set; } = null!;
        public int DataSourceId { get; set; }

        public virtual DataSource DataSource { get; set; } = null!;
    }
}
