namespace SchoolERP.Domain.Entities.Identity;

public class UserRole
{
    public string UserId { get; set; } = default!;
    public string RoleId { get; set; } = default!;

    public User User { get; set; } = default!;
    public Role Role { get; set; } = default!;
   public ICollection<UserRole> Users { get; set; } = new List<UserRole>();

}
