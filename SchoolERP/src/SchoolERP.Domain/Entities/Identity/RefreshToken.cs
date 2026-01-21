namespace SchoolERP.Domain.Entities.Identity;

public class RefreshToken
{
    public string Id { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }

    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
