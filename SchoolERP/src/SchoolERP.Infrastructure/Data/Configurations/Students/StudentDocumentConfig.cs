using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentDocumentConfig : IEntityTypeConfiguration<StudentDocument>
{
    public void Configure(EntityTypeBuilder<StudentDocument> builder)
    {
        builder.ToTable("StudentDocuments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentType)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.FileUrl)
               .HasMaxLength(500)
               .IsRequired();
    }
}
