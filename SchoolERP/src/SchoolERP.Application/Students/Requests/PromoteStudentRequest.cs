namespace SchoolERP.Application.Students.Requests;

public sealed class PromoteStudentRequest
{
    public string StudentId { get; set; } = default!;

    public string FromAcademicYearId { get; set; } = default!;
    public string ToAcademicYearId { get; set; } = default!;

    public string FromClassId { get; set; } = default!;
    public string FromSectionId { get; set; } = default!;

    public string ToClassId { get; set; } = default!;
    public string ToSectionId { get; set; } = default!;

    public bool IsPassout { get; set; }   // final year complete
    public bool IsTc { get; set; }        // transfer certificate

    public string? Remarks { get; set; }
}
