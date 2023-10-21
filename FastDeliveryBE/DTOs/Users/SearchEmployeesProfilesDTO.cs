namespace FastDeliveryBE.DTOs.Users
{
    public class SearchUsersDTO
    {
        public Guid? UserID { get; set; }

        public int? DepartmentID { get; set; }

        public int? SubDepartmentID { get; set; }


        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
