using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagementBE.DTOs.Attachments
{
    public class AttachmentTypeInfo
    {
        
        public int ID { get; set; }


        [Required]       
        public string Name { get; set; }
    }
}
