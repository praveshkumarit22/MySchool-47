namespace SchoolERP.Domain.Entities.Students;

/// <summary>
/// WHY this entity exists:
/// - Admission is a business event.
/// - Used for audit, re-admission, migration, compliance.
/// - A student can have multiple admissions (school change, rejoin).
/// </summary>
public class StudentAdmission
{
    public string Id { get; set; } = default!;

    public string StudentId { get; set; } = default!;
    public string AcademicYearId { get; set; } = default!;

    public DateTime AdmissionDate { get; set; }
    public string AdmissionType { get; set; } = default!; // New, Transfer, Rejoin
    public string? Remarks { get; set; }

    public Student Student { get; set; } = default!;
}
