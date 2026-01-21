using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.DTOs;
using SchoolERP.Application.Identity.Requests.Users;
using SchoolERP.Domain.Entities.Identity;
using SchoolERP.Infrastructure.Data;
using SchoolERP.Infrastructure.Identity.Security;

namespace SchoolERP.Infrastructure.Identity.Services;

public class UserService : IUserService
{
    private readonly SchoolDbContext _db;
    private readonly PasswordHasher _hasher;

    public UserService(SchoolDbContext db, PasswordHasher hasher)
    {
        _db = db;
        _hasher = hasher;
    }
    public async Task<string> CreateAsync(CreateUserRequest request, CancellationToken ct)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),   // or however you generate string IDs
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.IsActive,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync(ct);

        return user.Id;
    }


    public async Task<string> CreateAsync(CreateUserRequest request)
    {
        var user = new User
        {
            UserName = request.UserName, 
            Email = request.Email, 
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.IsActive,
            PasswordHash = _hasher.Hash(request.Password)
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        if (request.RoleIds.Any())
            await AssignRolesAsync(user.Id, request.RoleIds);

        return user.Id;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _db.Users
            .Select(user => new UserDto 
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            })
            .ToListAsync();
    }


    public async Task AssignRolesAsync(string userId, List<string> roleIds)
    {
        var existing = _db.UserRoles.Where(x => x.UserId == userId);
        _db.UserRoles.RemoveRange(existing);

        foreach (var roleId in roleIds)
        {
            _db.UserRoles.Add(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
        }

        await _db.SaveChangesAsync();
    }




    public async Task DisableAsync(string id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return;

        user.IsActive = false;
        await _db.SaveChangesAsync();
    }
}
