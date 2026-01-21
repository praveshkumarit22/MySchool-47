using SchoolERP.Application.Identity;
using SchoolERP.Domain.Entities.Identity;

namespace SchoolERP.Infrastructure.Data.Seed;

public static class IdentitySeed
{
    public static async Task SeedAsync(SchoolDbContext db)
    {
        if (db.Roles.Any()) return;

        var superAdminRole = new Role
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Super Administrator",
            NormalizedName = "SUPER ADMINISTRATOR",
            Code = "SUPER_ADMIN",
            IsDeleted = false
        };

        var permissions = PermissionCatalog.All
            .Select(p => new Permission
            {
                Id = Guid.NewGuid().ToString(),
                Name = p.Name,
                Key = p.Key,
                Group = p.Group,
                IsDeleted = false
            }).ToList();

        db.Roles.Add(superAdminRole);
        db.Permissions.AddRange(permissions);

        db.RolePermissions.AddRange(
            permissions.Select(p => new RolePermission
            {
                RoleId = superAdminRole.Id,
                PermissionId = p.Id
            })
        );

        var superAdmin = new User
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "System",
            LastName = "Admin",
            Email = "admin@schoolerp.com",
            UserName = "superadmin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            IsActive = true
        };

        db.Users.Add(superAdmin);

        db.UserRoles.Add(new UserRole
        {
            UserId = superAdmin.Id,
            RoleId = superAdminRole.Id
        });

        await db.SaveChangesAsync();
    }

    // backward compatibility
    public static Task Seed(SchoolDbContext db)
        => SeedAsync(db);

    //MenuSeed.Seed(db);

}
