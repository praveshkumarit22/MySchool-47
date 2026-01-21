using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Students;

public class Student : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string AdmissionNo { get; set; } = default!;
    public string Status { get; set; } = "Active"; // Active | TC | Drop | Passout
    public bool IsDeleted { get; set; }

    public StudentProfile Profile { get; set; } = default!;
    public ICollection<StudentGuardian> Guardians { get; set; } = new List<StudentGuardian>();
    public ICollection<StudentDocument> Documents { get; set; } = new List<StudentDocument>();
    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public ICollection<StudentStatusHistory> StatusHistory { get; set; } = new List<StudentStatusHistory>();
}
