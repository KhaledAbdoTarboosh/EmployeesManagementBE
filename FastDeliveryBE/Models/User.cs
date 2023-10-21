using System;
using System.Collections.Generic;

namespace FastDeliveryBE.Models
{
    public partial class User
    {
        public User()
        {
            Departments = new HashSet<Department>();
            Requests = new HashSet<Request>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool Gender { get; set; }
        public string FullName { get; set; } = null!;
        public string? Nationality { get; set; }
        public DateTime? Dob { get; set; }
        public int? SubDepartmentId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
