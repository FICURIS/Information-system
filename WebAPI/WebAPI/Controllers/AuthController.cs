using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TodoDb _db;

        public AuthController(TodoDb db)
        {
            _db = db;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDto dto)
        {
            var user = await _db.User
                .FirstOrDefaultAsync(u =>
                    u.Login == dto.Login &&
                    u.Password == dto.Password);

            if (user == null)
                return Unauthorized("Неверный логин или пароль");

            return Ok(user);
        }

    [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto dto)
        {
            var exists = await _db.User.AnyAsync(u => u.Login == dto.Login);

            if (exists)
                return BadRequest("Пользователь уже существует");

            var user = new User
            {
                Login = dto.Login,
                Password = dto.Password,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Email = dto.Email
            };

            _db.User.Add(user);
            await _db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
