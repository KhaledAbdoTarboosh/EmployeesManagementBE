using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [StringLength(100)]
        public string CertificateName { get; set; }

      
        [StringLength(50)]
        public string Organization { get; set; }


           
        public DateTime IssueDate { get; set; }


              
        public DateTime ExpirationDate { get; set; }
        

        [Required]
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

    }
}
