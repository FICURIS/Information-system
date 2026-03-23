using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserEnrollmentController : ControllerBase
    {
        private readonly TodoDb _db;

        public UserEnrollmentController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEnrollment>>> GetAll()
        {
            return await _db.UserEnrollment.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEnrollment>> Get(int id)
        {
            var userEnrollment = await _db.UserEnrollment.FindAsync(id);

            if (userEnrollment == null)
                return NotFound();

            return userEnrollment;
        }

        [HttpPost]
        public async Task<ActionResult<UserEnrollment>> Create(UserEnrollment userEnrollment)
        {
            _db.UserEnrollment.Add(userEnrollment);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = userEnrollment.UserEnrollmentID }, userEnrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserEnrollment inputUserEnrollment)
        {
            var userEnrollment = await _db.UserEnrollment.FindAsync(id);

            if (userEnrollment == null)
                return NotFound();

            userEnrollment.EnrollDate = inputUserEnrollment.EnrollDate;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userEnrollment = await _db.UserEnrollment.FindAsync(id);

            if (userEnrollment == null)
                return NotFound();

            _db.UserEnrollment.Remove(userEnrollment);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}