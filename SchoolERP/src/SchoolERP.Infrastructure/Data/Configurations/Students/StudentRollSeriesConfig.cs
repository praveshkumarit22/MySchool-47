using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentRollSeriesConfig : IEntityTypeConfiguration<StudentRollSeries>
{
    public void Configure(EntityTypeBuilder<StudentRollSeries> builder)
    {
        builder.ToTable("StudentRollSeries");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new
        {
            x.TenantId,
            x.AcademicYearId,
            x.ClassId,
            x.SectionId
        }).IsUnique();
    }
}
