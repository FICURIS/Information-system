using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class PhoneNumberController : ControllerBase
{
    private readonly IPhoneNumberService _service;

    public PhoneNumberController(IPhoneNumberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAll());

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
        => Ok(await _service.GetByUserId(userId));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var phone = await _service.GetById(id);
        if (phone == null) return NotFound();

        return Ok(phone);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PhoneNumber phone)
    {
        try
        {
            var created = await _service.Create(phone);
            return Ok(created);
        }
        catch
        {
            return BadRequest("User does not exist");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _service.Delete(id))
            return NotFound();

        return NoContent();
    }
}