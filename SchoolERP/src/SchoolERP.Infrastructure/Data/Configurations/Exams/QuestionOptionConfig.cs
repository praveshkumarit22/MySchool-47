using SchoolERP.Domain.Entities.Exams;

public sealed class QuestionOptionConfig : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> b)
    {
        b.ToTable("QuestionOptions");
        b.HasKey(x => x.Id);
    }
}
