using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var role = await _service.GetById(id);
        if (role == null) return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Role role)
    {
        var created = await _service.Create(role);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Role role)
    {
        if (!await _service.Update(id, role))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (!await _service.Delete(id))
                return NotFound();

            return NoContent();
        }
        catch
        {
            return BadRequest("Role is used by users");
        }
    }
}