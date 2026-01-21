using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Platform.DTOs;

public interface IMenuService
{
    Task<List<MenuDto>> GetMyMenusAsync(CancellationToken ct);
}
