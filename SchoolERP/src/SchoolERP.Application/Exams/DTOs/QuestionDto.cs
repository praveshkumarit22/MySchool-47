namespace SchoolERP.Application.Exams.Dtos;

public sealed record QuestionDto(
    string Id,
    string Text,
    string Type,
    decimal DefaultMarks);
