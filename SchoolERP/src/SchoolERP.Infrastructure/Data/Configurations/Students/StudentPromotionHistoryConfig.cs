using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentPromotionHistoryConfig : IEntityTypeConfiguration<StudentPromotionHistory>
{
    public void Configure(EntityTypeBuilder<StudentPromotionHistory> builder)
    {
        builder.ToTable("StudentPromotionHistory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Remarks)
               .HasMaxLength(300);
    }
}
