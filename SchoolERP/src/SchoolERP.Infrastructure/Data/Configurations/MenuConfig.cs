using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Identity;

namespace SchoolERP.Infrastructure.Data.Configurations;

public sealed class MenuConfig : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Route).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Group).HasMaxLength(100).IsRequired();

        builder.Property(x => x.DisplayOrder).IsRequired();

        // self reference (menu tree)
        builder.HasOne(x => x.Parent)
               .WithMany(x => x.Children)
               .HasForeignKey(x => x.ParentId); 

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
