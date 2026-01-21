namespace SchoolERP.Application.Identity;

public static class PermissionCatalog
{
    public static readonly List<(string Name, string Key, string Group)> All = new()
    {
        ("View Users", "Users.View", "Users"),
        ("Create Users", "Users.Create", "Users"),

        ("View Roles", "Roles.View", "Security"),
        ("Create Roles", "Roles.Create", "Security"),

        ("View Students", "Students.View", "Students"),
        ("Create Students", "Students.Create", "Students"),
    };
}
