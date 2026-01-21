namespace SchoolERP.Application.Identity;

public static class Permissions
{
    // -------- USERS --------
    public const string Users_View = "Users.View";
    public const string Users_Create = "Users.Create";
    public const string Users_Update = "Users.Update";
    public const string Users_Delete = "Users.Delete";

    // -------- ROLES --------
    public const string Roles_View = "Roles.View";
    public const string Roles_Create = "Roles.Create";

    // -------- STUDENTS (future) --------
    public const string Students_View = "Students.View";
    public const string Students_Create = "Students.Create";
    public const string Students_Update = "Students.Update";
}
