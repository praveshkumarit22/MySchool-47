using SchoolERP.Application.Common.Interfaces;
using SchoolERP.Application.Platform.DTOs;
using SchoolERP.Infrastructure.Data;

public class MenuService : IMenuService
{
    private readonly SchoolDbContext _db;
    private readonly ICurrentUser _currentUser;

    public MenuService(SchoolDbContext db, ICurrentUser currentUser)
    {
        _db = db;
        _currentUser = currentUser;
    }

    public async Task<List<MenuDto>> GetMyMenusAsync(CancellationToken ct)
    {
        var permissions = _currentUser.Permissions;

        return await _db.Menus
            .Where(m => m.Permissions.Any(mp => permissions.Contains(mp.Permission.Key)))
            .OrderBy(x => x.Group).ThenBy(x => x.DisplayOrder)
            .Select(x => new MenuDto(
                x.Id, x.Title, x.Route, x.Icon, x.Group, x.DisplayOrder, x.ParentId))
            .ToListAsync(ct);
    }
}
