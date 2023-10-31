using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmployeesManagementBE.DTOs.Attachments;

namespace EmployeesManagementBE.DTOs.Employees
{
    public class EmployeeInfo
    {

        
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

        public int? EvaluationRate { get; set; }


        public double? Bounce { get; set; }

        public int? YearsOfExperience { get; set; }




        [Required]
      
        public int DepartmentID { get; set; }

        public ICollection<AttachmentInfo> Attachments { get; set; } = new List<AttachmentInfo>();

        public ICollection<SkillInfo> Skills { get; set; } = new List<SkillInfo>();

        public ICollection<CertificationInfo> Certifications { get; set; } = new List<CertificationInfo>();

        public ICollection<ExperienceInfo> Experiences { get; set; } = new List<ExperienceInfo>();

        


    }
}
