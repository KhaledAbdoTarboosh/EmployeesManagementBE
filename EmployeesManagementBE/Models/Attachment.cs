using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("TypeID")]
        public AttachmentType Type { get; set; }


        [Required]
        [StringLength(3)]
        public string Extension { get; set; }


        [Required]
        [StringLength(500)]
        public string URL { get; set; }


        [Required]
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }


    }
}
