using SchoolERP.Domain.Entities.Exams;

public sealed class ExamPaperSetConfig : IEntityTypeConfiguration<ExamPaperSet>
{
    public void Configure(EntityTypeBuilder<ExamPaperSet> b)
    {
        b.ToTable("ExamPaperSets");
        b.HasKey(x => x.Id);
    }
}
