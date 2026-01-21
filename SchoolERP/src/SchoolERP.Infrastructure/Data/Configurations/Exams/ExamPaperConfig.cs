using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class ExamPaperConfig : IEntityTypeConfiguration<ExamPaper>
{
    public void Configure(EntityTypeBuilder<ExamPaper> builder)
    {
        builder.ToTable("ExamPapers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExamId)
               .IsRequired();

        builder.Property(x => x.SubjectId)
               .IsRequired();

        // Prevent silent truncation of marks
        builder.Property(x => x.MaxMarks)
               .HasPrecision(7, 2);

        builder.Property(x => x.DurationMinutes)
               .IsRequired();
    }
}
