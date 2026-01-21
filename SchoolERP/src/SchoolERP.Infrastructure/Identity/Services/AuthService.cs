using BCrypt.Net;
using Microsoft.Extensions.Options;
using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.DTOs;
using SchoolERP.Application.Identity.Interfaces;
using SchoolERP.Application.Identity.Requests.Auth;

using SchoolERP.Infrastructure.Identity.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService,
        IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUserNameOrEmailAsync(request.UserNameOrEmail);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName
        };


        var fullUser = await _userRepository.GetWithRolesAndPermissionsAsync(user.Id)
                       ?? throw new UnauthorizedAccessException();

        var roles = fullUser.UserRoles
            .Select(x => x.Role.Name)
            .Distinct()
            .ToList();

        var permissions = fullUser.UserRoles
            .SelectMany(x => x.Role.Permissions)
            .Select(x => x.Permission.Key)
            .Distinct()
            .ToList();

        var accessToken = _jwtService.GenerateAccessToken(fullUser, roles, permissions);





        //var accessToken = _jwtService.GenerateAccessToken(user, userDto.Roles, userDto.Permissions);



        var refreshToken = _jwtService.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenMinutes);

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = expiresAt,
            User = userDto
        };
    }
     


}
