namespace SchoolERP.Domain.Entities.Academics;

public class TeacherSubject
{
    public string Id { get; set; } = default!;
    public string TeacherId { get; set; } = default!;
    public string ClassSubjectId { get; set; } = default!;

    public Teacher Teacher { get; set; } = default!;
    public ClassSubject ClassSubject { get; set; } = default!;
}
