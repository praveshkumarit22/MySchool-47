namespace SchoolERP.Application.Exams.Dtos;

public sealed record StudentMarksheetDto(
    string StudentId,
    string ExamId,
    decimal TotalMarks,
    decimal ObtainedMarks,
    decimal Percentage,
    string ResultStatus,
    List<StudentMarksheetSubjectDto> Subjects);

public sealed record StudentMarksheetSubjectDto(
    string SubjectId,
    decimal MaxMarks,
    decimal ObtainedMarks,
    bool IsAbsent,
    string? Grade);
