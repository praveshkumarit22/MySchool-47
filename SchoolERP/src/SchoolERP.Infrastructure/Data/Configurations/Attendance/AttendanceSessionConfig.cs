using SchoolERP.Domain.Entities.Attendance;

namespace SchoolERP.Infrastructure.Data.Configurations.Attendance;

public sealed class AttendanceSessionConfig : IEntityTypeConfiguration<AttendanceSession>
{
    public void Configure(EntityTypeBuilder<AttendanceSession> builder)
    {
        builder.ToTable("AttendanceSessions");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.AcademicYearId, x.ClassId, x.SectionId, x.Date })
               .IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
