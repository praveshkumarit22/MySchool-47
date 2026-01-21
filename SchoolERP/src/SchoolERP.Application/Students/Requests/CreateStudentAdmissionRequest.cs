namespace SchoolERP.Application.Students.Requests;

public sealed class CreateStudentAdmissionRequest
{
    // Profile
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Gender { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string? BloodGroup { get; set; }

    // Address
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Pincode { get; set; }

    // Guardians
    public List<CreateStudentGuardianRequest> Guardians { get; set; } = new();

    // Initial enrollment
    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;
}
