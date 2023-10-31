using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        [Required]
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }
}
