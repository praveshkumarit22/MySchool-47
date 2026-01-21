namespace SchoolERP.Application.Identity.Dtos;

public sealed class PermissionDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Module { get; set; } = default!;

    public PermissionDto() { }

    public PermissionDto(string id, string name, string code, string module)
    {
        Id = id;
        Name = name;
        Code = code;
        Module = module;
    }
}
