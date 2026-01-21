using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class ClassSectionConfig : IEntityTypeConfiguration<ClassSection>
{
    public void Configure(EntityTypeBuilder<ClassSection> builder)
    {
        builder.ToTable("ClassSections");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.SchoolClassId, x.SectionId }).IsUnique();

        builder.HasOne(x => x.SchoolClass)
               .WithMany(x => x.Sections)
               .HasForeignKey(x => x.SchoolClassId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Section)
               .WithMany()
               .HasForeignKey(x => x.SectionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
