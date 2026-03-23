using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNumberController : ControllerBase
    {
        private readonly TodoDb _db;

        public PhoneNumberController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> GetAll()
        {
            return await _db.PhoneNumber.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumber>> Get(int id)
        {
            var phoneNumber = await _db.PhoneNumber.FindAsync(id);

            if (phoneNumber == null)
                return NotFound();

            return phoneNumber;
        }

        [HttpPost]
        public async Task<ActionResult<PhoneNumber>> Create(PhoneNumber phoneNumber)
        {
            _db.PhoneNumber.Add(phoneNumber);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = phoneNumber.PhoneNumberID }, phoneNumber);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PhoneNumber inputPhoneNumber)
        {
            var phoneNumber = await _db.PhoneNumber.FindAsync(id);

            if (phoneNumber == null)
                return NotFound();

            phoneNumber.Number = inputPhoneNumber.Number;
            
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var phoneNumber = await _db.PhoneNumber.FindAsync(id);

            if (phoneNumber == null)
                return NotFound();

            _db.PhoneNumber.Remove(phoneNumber);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}