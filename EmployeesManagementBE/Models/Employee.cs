using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EmployeesManagementBE.Models
{
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]        
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public DateTime HiringDate { get; set; }

        [Required]
        public int MonthlySalary { get; set; }

        [Required]
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public ICollection<Attachment> Attachments { get; set; }  = new List<Attachment>();

        public ICollection<Skill> Skills { get; set; } = new List<Skill>();

        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();

        public int EvaluationRate { get; set; }


    }
}
