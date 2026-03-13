using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestStatusController : ControllerBase
    {
        private readonly TodoDb _db;

        public RequestStatusController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestStatus>>> GetAll()
        {
            return await _db.RequestStatus.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestStatus>> Get(int id)
        {
            var requestStatus = await _db.RequestStatus.FindAsync(id);

            if (requestStatus == null)
                return NotFound();

            return requestStatus;
        }

        [HttpPost]
        public async Task<ActionResult<RequestStatus>> Create(RequestStatus requestStatus)
        {
            _db.RequestStatus.Add(requestStatus);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = requestStatus.StatusID }, requestStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RequestStatus inputRequestStatus)
        {
            var requestStatus = await _db.RequestStatus.FindAsync(id);

            if (requestStatus == null)
                return NotFound();

            requestStatus.StatusName = inputRequestStatus.StatusName;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requestStatus = await _db.RequestStatus.FindAsync(id);

            if (requestStatus == null)
                return NotFound();

            _db.RequestStatus.Remove(requestStatus);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}