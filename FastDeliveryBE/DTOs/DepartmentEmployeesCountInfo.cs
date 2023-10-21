namespace FastDeliveryBE.DTOs
{
    public class DepartmentEmployeesCountInfo
    {
        public int DepartmentId { get; set; }

        public byte DepartmentTypeId { get; set; }

        public string DepartmentName { get; set; } = null!;

        public int EmployeesCount { get; set; }
    }
}
