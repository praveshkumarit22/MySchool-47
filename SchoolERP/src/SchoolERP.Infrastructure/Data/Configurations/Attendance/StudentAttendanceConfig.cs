using SchoolERP.Domain.Entities.Attendance;

namespace SchoolERP.Infrastructure.Data.Configurations.Attendance;

public sealed class StudentAttendanceConfig : IEntityTypeConfiguration<StudentAttendance>
{
    public void Configure(EntityTypeBuilder<StudentAttendance> builder)
    {
        builder.ToTable("StudentAttendances");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.AttendanceSessionId, x.StudentId })
               .IsUnique(); 
    }
}
