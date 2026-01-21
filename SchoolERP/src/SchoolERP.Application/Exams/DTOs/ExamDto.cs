namespace SchoolERP.Application.Exams.Dtos;

public sealed record ExamDto(
    string Id,
    string Name,
    string Term,
    string Status);
