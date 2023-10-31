using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.DTOs.Employees
{
    public class CertificationInfo
    {

        public int ID { get; set; }


        [Required]
        [StringLength(100)]
        public string CertificateName { get; set; }


        [StringLength(50)]
        public string Organization { get; set; }



        public DateTime IssueDate { get; set; }



        public DateTime ExpirationDate { get; set; }


        [Required]     
        public int EmployeeID { get; set; }
    }
}
