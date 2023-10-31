using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.DTOs.Attachments
{
    public class AttachmentInfo
    {
      
        public int ID { get; set; }

        [Required]
  
        public int TypeID { get; set; }


        [Required]
        [StringLength(3)]
        public string Extension { get; set; }


        [Required]
        [StringLength(500)]
        public string URL { get; set; }


        [Required]       
        public int EmployeeID { get; set; }


        [Required]
        public byte[] AttachmentBytes { get; set; }
    }
}
