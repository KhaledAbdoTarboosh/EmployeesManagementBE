namespace FastDeliveryBE.DTOs.Employees
{
    public class SearchEmployeesDTO
    {
        public Expression<Func<Employee, bool>> criteria { get; set; }




        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
