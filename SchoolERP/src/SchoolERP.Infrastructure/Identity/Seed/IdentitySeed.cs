using Microsoft.EntityFrameworkCore;
using SchoolERP.Domain.Entities;
using SchoolERP.Domain.Entities.Identity;

namespace SchoolERP.Infrastructure.Identity.Seed;

public static class IdentitySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var adminRole = new Role
        {
            Id = "1",
            Name = "Super Admin",
            Code = "SUPER_ADMIN"
        };

        var adminUser = new User
        {
            Id = "1",
            FirstName = "System",
            LastName = "Admin",
            UserName = "admin",
            Email = "admin@schoolerp.com",
            PasswordHash = "ADMIN_RESET_REQUIRED",
            IsActive = true
        };

        modelBuilder.Entity<Role>().HasData(adminRole);
        modelBuilder.Entity<User>().HasData(adminUser);
        modelBuilder.Entity<UserRole>().HasData(new UserRole
        {
            UserId = "1",
            RoleId = "1"
        });
    }
}   
