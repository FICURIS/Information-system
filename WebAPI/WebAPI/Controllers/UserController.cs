using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TodoDb _db;

        public UserController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _db.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _db.User.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            _db.User.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User inputUser)
        {
            var user = await _db.User.FindAsync(id);

            if (user == null)
                return NotFound();

            user.Login = inputUser.Login;
            user.PasswordHash = inputUser.PasswordHash;
            user.LastName = inputUser.LastName;
            user.FirstName = inputUser.FirstName;
            user.MiddleName = inputUser.MiddleName;
            user.Email = inputUser.Email;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _db.User.FindAsync(id);

            if (user == null)
                return NotFound();

            _db.User.Remove(user);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}