using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _service.Login(dto.Login, dto.Password);

        if (token == null)
            return Unauthorized("Invalid login or password");

        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Login = dto.Login,
            PasswordHash = dto.Password,
            Email = dto.Email
        };

        var created = await _service.Register(user);

        return Ok(created);
    }
}