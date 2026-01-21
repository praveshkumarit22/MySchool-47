namespace SchoolERP.Application.Academics.DTOs;

public record AcademicYearDto(
    string Id,
    string Name,
    DateOnly StartDate,
    DateOnly EndDate,
    bool IsCurrent);
