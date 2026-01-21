namespace SchoolERP.Application.Students.Dtos;

public sealed record StudentHistoryDto(
    string AcademicYearId,
    string ClassId,
    string SectionId,
    string RollNumber,
    string FinalStatus,
    DateTime ArchivedOn);
