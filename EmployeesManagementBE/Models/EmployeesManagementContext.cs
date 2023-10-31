namespace EmployeesManagementBE.Models
{
    public partial class EmployeesManagementContext : DbContext
    {
        public EmployeesManagementContext()
        {
        }

        public EmployeesManagementContext(DbContextOptions<EmployeesManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; } = null!;


        public virtual DbSet<Attachment> Attachments { get; set; } = null!;

        public virtual DbSet<Certification> Certification { get; set; } = null!;

        public virtual DbSet<Department> Department { get; set; } = null!;

        public virtual DbSet<Experience> Experiences { get; set; } = null!;

        public virtual DbSet<Skill> Skills { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=EmployeesManagement;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
