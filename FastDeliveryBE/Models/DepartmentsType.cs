using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class DepartmentsType
    {
        public DepartmentsType()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
    }
}
