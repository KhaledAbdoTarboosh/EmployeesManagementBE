using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.DTOs.Employees
{
    public class DepartmentInfo
    {
        
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [Required]
        public int BounceRatio { get; set; }
    }
}
