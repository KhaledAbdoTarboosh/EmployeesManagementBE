using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.Models
{
    public class Experience
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string Organization { get; set; }


        [Required]
        public DateTime HiringDate { get; set; }


        [Required]
        public DateTime LeaveDate { get; set; }

        [Required]
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

    }
}
