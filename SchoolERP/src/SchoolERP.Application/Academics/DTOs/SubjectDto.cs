namespace SchoolERP.Application.Academics.DTOs;

public record SubjectDto(
    string Id,
    string Name,
    string? Code,
    bool IsElective);
