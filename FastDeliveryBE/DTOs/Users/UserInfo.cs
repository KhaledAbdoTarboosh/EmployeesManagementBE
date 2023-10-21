namespace FastDeliveryBE.DTOs.Users
{
    public class UserInfo
    {
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

      
    }
}
