namespace FastDeliveryBE.DTOs.DepartmentApprovals
{
    public class SearchDeprtmentApprovalDTO
    {

        public Guid? operationID { get; set; }


        public int? departmentID { get; set; }


        public int? managerDepartmentID { get; set; }



        public int? approvalLevel { get; set; }



        public bool? forManager { get; set; }
    }
}
