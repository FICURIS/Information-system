using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRolesService _service;

    public UserRolesController(IUserRolesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAll());

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
        => Ok(await _service.GetByUserId(userId));

    [HttpPost]
    public async Task<IActionResult> AssignRole(UserRoles userRole)
    {
        try
        {
            var created = await _service.AssignRole(userRole);
            return Ok(created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveRole(int id)
    {
        if (!await _service.RemoveRole(id))
            return NotFound();

        return NoContent();
    }
}