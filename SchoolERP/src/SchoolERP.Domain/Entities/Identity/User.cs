using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Identity;

public class User : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    // --------------------
    // Core profile
    // --------------------
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string? PhoneNumber { get; set; }

    // --------------------
    // Security
    // --------------------
    public string PasswordHash { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    // --------------------
    // RBAC
    // --------------------
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    // Optional convenience (not mapped, helps services/UI)
    public IEnumerable<Role> Roles => UserRoles.Select(x => x.Role);

    // --------------------
    // Refresh tokens
    // --------------------
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
