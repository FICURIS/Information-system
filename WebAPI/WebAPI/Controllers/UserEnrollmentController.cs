using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class UserEnrollmentController : ControllerBase
{
    private readonly IUserEnrollmentService _service;

    public UserEnrollmentController(IUserEnrollmentService service)
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
        var item = await _service.GetById(id);
        if (item == null) return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserEnrollment enrollment)
    {
        try
        {
            var created = await _service.Create(enrollment);
            return Ok(created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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