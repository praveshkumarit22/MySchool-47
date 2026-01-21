using SchoolERP.Application.Platform.DTOs;

namespace SchoolERP.Application.Platform.Contracts;

public interface IMenuService
{
    Task<List<MenuDto>> GetForUserAsync(string  userId);
}
