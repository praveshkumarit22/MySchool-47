namespace SchoolERP.Application.Platform.DTOs;

//public record MenuDto(
//    string  Id,
//    string Title,
//    string Route,
//    string Icon,
//    List<MenuDto> Children
//);

public sealed record MenuDto(
    string Id,
    string Title,
    string Route,
    string Icon,
    string Group,
    int Order,
    string? ParentId);


