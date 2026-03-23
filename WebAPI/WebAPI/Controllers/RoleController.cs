using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly TodoDb _db;

        public RoleController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return await _db.Role.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await


                _db.Role.FindAsync(id);

            if (role == null)
                return NotFound();

            return role;
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(Role role)
        {
            _db.Role.Add(role);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = role.RoleID }, role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _db.Role.FindAsync(id);

            if (role == null)
                return NotFound();

            _db.Role.Remove(role);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
