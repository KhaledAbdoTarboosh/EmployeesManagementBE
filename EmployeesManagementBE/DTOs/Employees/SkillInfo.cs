using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.DTOs.Employees
{
    public class SkillInfo
    {
        
        public int ID { get; set; }


        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        [Required]        
        public int EmployeeID { get; set; }
    }
}
