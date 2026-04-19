using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

public class AuthService : IAuthService
{
    private readonly TodoDb _db;
    private readonly IConfiguration _config;

    public AuthService(TodoDb db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public async Task<string?> Login(string login, string password)
    {
        var user = await _db.User.FirstOrDefaultAsync(u => u.Login == login);

        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return GenerateJwtToken(user);
    }

    public async Task<User> Register(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

        _db.User.Add(user);
        await _db.SaveChangesAsync();

        return user;
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _config.GetSection("Jwt");

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim("UserId", user.UserID.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}