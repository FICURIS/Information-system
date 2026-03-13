using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly TodoDb _db;

        public RequestController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetAll()
        {
            return await _db.Request.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> Get(int id)
        {
            var request = await _db.Request.FindAsync(id);

            if (request == null)
                return NotFound();

            return request;
        }

        [HttpPost]
        public async Task<ActionResult<Request>> Create(Request request)
        {
            _db.Request.Add(request);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = request.RequestID }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Request inputRequest)
        {
            var request = await _db.Request.FindAsync(id);

            if (request == null)
                return NotFound();

            request.UserID = inputRequest.UserID;
            request.CourseID = inputRequest.CourseID;
            request.StatusID = inputRequest.StatusID;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _db.Request.FindAsync(id);

            if (request == null)
                return NotFound();

            _db.Request.Remove(request);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}