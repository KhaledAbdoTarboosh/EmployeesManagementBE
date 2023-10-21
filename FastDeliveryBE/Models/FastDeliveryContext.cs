namespace FastDeliveryBE.Models
{
    public partial class FastDeliveryContext : DbContext
    {
        public FastDeliveryContext()
        {
        }

        public FastDeliveryContext(DbContextOptions<FastDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalType> ApprovalTypes { get; set; } = null!;
        public virtual DbSet<ApprovalsPhase> ApprovalsPhases { get; set; } = null!;
        public virtual DbSet<AssignedTask> AssignedTasks { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<DataSource> DataSources { get; set; } = null!;
        public virtual DbSet<DataSourceItem> DataSourceItems { get; set; } = null!;
        public virtual DbSet<DecisionsType> DecisionsTypes { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentsApprovalDelegation> DepartmentsApprovalDelegations { get; set; } = null!;
        public virtual DbSet<DepartmentsApprovalLevel> DepartmentsApprovalLevels { get; set; } = null!;
        public virtual DbSet<DepartmentsType> DepartmentsTypes { get; set; } = null!;
        public virtual DbSet<ElementsType> ElementsTypes { get; set; } = null!;
        public virtual DbSet<Form> Forms { get; set; } = null!;
        public virtual DbSet<FormElement> FormElements { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<PhaseDecision> PhaseDecisions { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestElement> RequestElements { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<TaskOwner> TaskOwners { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersGroup> UsersGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=FastDelivery;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ApprovalsPhase>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalTypeId).HasColumnName("ApprovalTypeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.ApprovalType)
                    .WithMany(p => p.ApprovalsPhases)
                    .HasForeignKey(d => d.ApprovalTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApprovalsPhases_ApprovalTypes");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.ApprovalsPhases)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApprovalsPhases_Forms");
            });

            modelBuilder.Entity<AssignedTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_RequestApprovals");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("TaskID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.DecisionId).HasColumnName("DecisionID");

                entity.Property(e => e.ExecutedOn).HasPrecision(2);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PhaseId).HasColumnName("PhaseID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.TimeOutOn).HasPrecision(2);

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.AssignedTasks)
                    .HasForeignKey(d => d.PhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestApprovals_ApprovalsPhases");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.AssignedTasks)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestApprovals_Requests");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("AttachmentID");

                entity.Property(e => e.Extension)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestElementId).HasColumnName("RequestElementID");

                entity.HasOne(d => d.RequestElement)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.RequestElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attachments_RequestElements");
            });

            modelBuilder.Entity<DataSource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DataSourceItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(50);

                entity.Property(e => e.DataSourceId).HasColumnName("DataSourceID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.DataSourceItems)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataSourceItems_DataSources");
            });

            modelBuilder.Entity<DecisionsType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.DepartmentName).HasMaxLength(100);

                entity.Property(e => e.DepartmentTypeId).HasColumnName("DepartmentTypeID");

                entity.Property(e => e.ManagerUserId).HasColumnName("ManagerUserID");

                entity.Property(e => e.ParentDepartmentId).HasColumnName("ParentDepartmentID");

                entity.HasOne(d => d.DepartmentType)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepartmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_DepartmentsTypes");

                entity.HasOne(d => d.ManagerUser)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerUserId)
                    .HasConstraintName("FK_Departments_Users");
            });

            modelBuilder.Entity<DepartmentsApprovalDelegation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.DelegatedUserId).HasColumnName("DelegatedUserID");
            });

            modelBuilder.Entity<DepartmentsApprovalLevel>(entity =>
            {
                entity.ToTable("DepartmentsApprovalLevel");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.ManagerDepartmentId).HasColumnName("ManagerDepartmentID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentsApprovalLevelDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentsApprovalLevel_Departments");

                entity.HasOne(d => d.ManagerDepartment)
                    .WithMany(p => p.DepartmentsApprovalLevelManagerDepartments)
                    .HasForeignKey(d => d.ManagerDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentsApprovalLevel_Departments1");
            });

            modelBuilder.Entity<DepartmentsType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ElementsType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<FormElement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementOwnerId).HasColumnName("ElementOwnerID");

                entity.Property(e => e.ElementTypeId).HasColumnName("ElementTypeID");

                entity.Property(e => e.ExternalSourceId).HasColumnName("ExternalSourceID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.ElementType)
                    .WithMany(p => p.FormElements)
                    .HasForeignKey(d => d.ElementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormElements_ElementsTypes");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormElements)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormElements_FormElements1");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.FormElements)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_FormElements_DataSources");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ArName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PhaseDecision>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DecisionId).HasColumnName("DecisionID");

                entity.Property(e => e.PhaseId).HasColumnName("PhaseID");

                entity.HasOne(d => d.Decision)
                    .WithMany(p => p.PhaseDecisions)
                    .HasForeignKey(d => d.DecisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhaseDecisions_DecisionsTypes");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.PhaseDecisions)
                    .HasForeignKey(d => d.PhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhaseDecisions_ApprovalsPhases");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.RequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("RequestID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.CurrentPhaseId).HasColumnName("CurrentPhaseID");

                entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UpdatedOn).HasPrecision(2);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Services");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Users");
            });

            modelBuilder.Entity<RequestElement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.FormElementId).HasColumnName("FormElementID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.FormElement)
                    .WithMany(p => p.RequestElements)
                    .HasForeignKey(d => d.FormElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestElements_FormElements");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestElements)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestElements_Requests");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Forms");
            });

            modelBuilder.Entity<TaskOwner>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.SubDepartmentId).HasColumnName("SubDepartmentID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersGroup>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasPrecision(2);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersGroups_Groups");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersGroups_Users");
            });

            //base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
