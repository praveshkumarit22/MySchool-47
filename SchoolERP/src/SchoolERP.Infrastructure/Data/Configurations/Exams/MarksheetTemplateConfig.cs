using SchoolERP.Domain.Entities.Exams;

public sealed class MarksheetTemplateConfig : IEntityTypeConfiguration<MarksheetTemplate>
{
    public void Configure(EntityTypeBuilder<MarksheetTemplate> b)
    {
        b.ToTable("MarksheetTemplates");
        b.HasKey(x => x.Id);
    }
}
