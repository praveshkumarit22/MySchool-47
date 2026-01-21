using System.Security.Cryptography;
using System.Text;

namespace SchoolERP.Infrastructure.Identity.Security;

public class PasswordHasher
{
    public string Hash(string password)
    {
        using var hmac = new HMACSHA256();
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }

    public bool Verify(string password, string storedHash)
        => Hash(password) == storedHash;
}
