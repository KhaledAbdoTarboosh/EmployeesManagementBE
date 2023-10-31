namespace EmployeesManagementBE.Helpers
{
    public class ActionModel
    {
        public bool IsDone { get; set; }     

        public string ProcessedBy { get; set; }

        public string ProcessedDate { get; set; }

        public Object Data { get; set; }

        public int ResultID { get; set; }

        public string ResultMessage { get; set; }

        public int Count { get; set; }


    }

    public class ActionResponse<T>
    {
        public bool IsDone { get; set; }      

        public string ProcessedBy { get; set; }

        public string ProcessedDate { get; set; }

        public T Data { get; set; }

        public int ResultID { get; set; }

        public string ResultMessage { get; set; }

        public int Count { get; set; }

    }


    public class LoginActionResponse<T>: ActionResponse<T>
    {
        public bool IsDone { get; set; }

        public string ProcessedBy { get; set; }

        public string ProcessedDate { get; set; }

       
        public int ResultID { get; set; }

        public string ResultMessage { get; set; }

        public int Count { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }
       

    }
}
