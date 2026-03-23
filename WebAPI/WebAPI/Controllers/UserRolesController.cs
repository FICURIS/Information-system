using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly TodoDb _db;

        public UserRolesController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetAll()
        {
            return await _db.UserRoles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoles>> Get(int id)
        {
            var userRoles = await
                
                
                _db.UserRoles.FindAsync(id);

            if (userRoles == null)
                return NotFound();

            return userRoles;
        }

        [HttpPost]
        public async Task<ActionResult<UserRoles>> Create(UserRoles userRoles)
        {
            _db.UserRoles.Add(userRoles);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = userRoles.UserRolesID }, userRoles);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role inputRole)
        {
            var role = await _db.Role.FindAsync(id);

            if (role == null)
                return NotFound();

            role.RoleName = inputRole.RoleName;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userRoles = await _db.UserRoles.FindAsync(id);

            if (userRoles == null)
                return NotFound();

            _db.UserRoles.Remove(userRoles);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}