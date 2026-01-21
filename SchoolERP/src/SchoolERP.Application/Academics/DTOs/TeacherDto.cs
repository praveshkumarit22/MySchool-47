namespace SchoolERP.Application.Academics.DTOs;

public record TeacherDto(
    string Id,
    string FullName,
    string? Email,
    string? Phone);
