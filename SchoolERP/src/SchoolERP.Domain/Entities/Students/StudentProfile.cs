namespace SchoolERP.Domain.Entities.Students;

public class StudentProfile
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = default!;
    public string? BloodGroup { get; set; }

    public string? AadhaarNo { get; set; }
    public string? PhotoUrl { get; set; }

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Pincode { get; set; }

    public Student Student { get; set; } = default!;
}
