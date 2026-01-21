using System.Globalization;

namespace SchoolERP.Application.Identity.Dtos;

public sealed class RoleDto
{
    public string Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Description { get; set; }

    public RoleDto() { }

    public RoleDto(string id, string name, string code, string? description)
    {
        Id = id;
        Name = name;
        Code = code;
        Description = description;
    }
}
