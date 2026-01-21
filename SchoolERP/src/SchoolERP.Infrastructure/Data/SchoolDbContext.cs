using SchoolERP.Application.Common.Contracts;
using SchoolERP.Domain.Entities.Academics;
using SchoolERP.Domain.Entities.Attendance;
using SchoolERP.Domain.Entities.Exams;
using SchoolERP.Domain.Entities.Identity;
using SchoolERP.Domain.Entities.Students;
using SchoolERP.Infrastructure.Data.Interceptors;

namespace SchoolERP.Infrastructure.Data;

public class SchoolDbContext : DbContext, IUnitOfWork
{
    private readonly ITenantContext _tenant;

    private readonly AuditSaveChangesInterceptor _auditInterceptor;

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options, ITenantContext tenant, AuditSaveChangesInterceptor auditInterceptor)
        : base(options)
    {
        _tenant = tenant;
        _auditInterceptor = auditInterceptor;
    }


    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuPermission> MenuPermissions => Set<MenuPermission>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentGuardian> StudentGuardians => Set<StudentGuardian>();
    public DbSet<StudentAdmission> StudentAdmissions => Set<StudentAdmission>();
    public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();
    public DbSet<StudentHistory> StudentHistories => Set<StudentHistory>();
    public DbSet<AttendanceSession> AttendanceSessions => Set<AttendanceSession>();
    public DbSet<StudentAttendance> StudentAttendances => Set<StudentAttendance>();

    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamSubject> ExamSubjects => Set<ExamSubject>();
    public DbSet<StudentMark> StudentMarks => Set<StudentMark>();

    public DbSet<StudentResult> StudentResults => Set<StudentResult>();
    public DbSet<StudentResultSubject> StudentResultSubjects => Set<StudentResultSubject>();

    // Exam Related
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuestionOption> QuestionOptions => Set<QuestionOption>();
    public DbSet<ExamPaper> ExamPapers => Set<ExamPaper>();
    public DbSet<ExamPaperSet> ExamPaperSets => Set<ExamPaperSet>();
    public DbSet<ExamPaperQuestion> ExamPaperQuestions => Set<ExamPaperQuestion>();

    public DbSet<MarksheetTemplate> MarksheetTemplates => Set<MarksheetTemplate>();


    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
 
    public DbSet<StudentDocument> StudentDocuments => Set<StudentDocument>();
    public DbSet<StudentStatusHistory> StudentStatusHistories => Set<StudentStatusHistory>();


    // Academic Related
    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
    public DbSet<SchoolClass> SchoolClasses => Set<SchoolClass>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<ClassSection> ClassSections => Set<ClassSection>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<ClassSubject> ClassSubjects => Set<ClassSubject>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<TeacherSubject> TeacherSubjects => Set<TeacherSubject>();


    public DbSet<StudentRollSeries> StudentRollSeries => Set<StudentRollSeries>();
    public DbSet<StudentPromotionHistory> StudentPromotionHistory => Set<StudentPromotionHistory>();
    public DbSet<StudentStatusHistory> StudentStatusHistory => Set<StudentStatusHistory>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Soft delete
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(SchoolDbContext)
                    .GetMethod(nameof(SetSoftDeleteFilter),
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                    ?.MakeGenericMethod(entityType.ClrType);

                method?.Invoke(null, new object[] { modelBuilder });
            }

            // Tenant isolation
            if (typeof(TenantEntity).IsAssignableFrom(entityType.ClrType)
                && !entityType.ClrType.IsAbstract)
            {
                var method = typeof(SchoolDbContext)
                    .GetMethod(nameof(SetTenantFilter),
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                    ?.MakeGenericMethod(entityType.ClrType);

                method?.Invoke(null, new object[] { modelBuilder });
            }
        }



        modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Permission>().HasQueryFilter(x => !x.IsDeleted);

        modelBuilder.Entity<ClassSection>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<ClassSubject>().HasQueryFilter(x => !x.IsDeleted);



        modelBuilder.Entity<UserRole>()
    .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<RolePermission>()
            .HasKey(x => new { x.RoleId, x.PermissionId });

        modelBuilder.Entity<Role>()
            .HasIndex(x => x.Code)
            .IsUnique();

        modelBuilder.Entity<Permission>()
            .HasIndex(x => x.Key)
            .IsUnique();
    }
    private static void SetSoftDeleteFilter<TEntity>(ModelBuilder builder)
    where TEntity : class, ISoftDelete
    {
        builder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
    }

    private static void SetTenantFilter<TEntity>(ModelBuilder builder)
        where TEntity : class
    {
        builder.Entity<TEntity>().HasIndex("TenantId");
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.CreatedBy = "1"; // from token later
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedBy = "1";
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditInterceptor);
    }

}
