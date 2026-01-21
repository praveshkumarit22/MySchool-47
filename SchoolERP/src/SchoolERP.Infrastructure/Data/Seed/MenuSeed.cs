using SchoolERP.Domain.Entities.Identity;
using SchoolERP.Infrastructure.Data;

public static class MenuSeed
{
    public static void Seed(SchoolDbContext db)
    {
        if (db.Menus.Any()) return;

        var usersMenu = new Menu
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Users",
            Route = "/admin/users",
            Icon = "users",
            Group = "Security",
            DisplayOrder = 1
        };


        var studentsMenu = new Menu
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Students",
            Route = "/admin/students",
            Icon = "graduation-cap",
            Group = "Academics",
            DisplayOrder = 2
        };

        db.Menus.AddRange(usersMenu, studentsMenu);

        var usersPermission = db.Permissions.First(x => x.Key == "Users.View");
        var studentsPermission = db.Permissions.First(x => x.Key == "Students.View");

        db.MenuPermissions.AddRange(
            new MenuPermission { MenuId = usersMenu.Id, PermissionId = usersPermission.Id },
            new MenuPermission { MenuId = studentsMenu.Id, PermissionId = studentsPermission.Id }
        );

        db.SaveChanges();
    }
}
