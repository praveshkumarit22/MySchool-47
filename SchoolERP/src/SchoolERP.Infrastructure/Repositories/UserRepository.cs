using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Identity.Interfaces;
using SchoolERP.Domain.Entities.Identity;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Identity;

public sealed class UserRepository : IUserRepository
{
    private readonly SchoolDbContext _db;

    public UserRepository(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
    {
        return await _db.Users
            .FirstOrDefaultAsync(x =>
                x.Email == userNameOrEmail ||
                x.UserName == userNameOrEmail);
    }

    public async Task<User?> GetWithRolesAndPermissionsAsync(string userId)
    {
        return await _db.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.Permissions)
                        .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }


}
