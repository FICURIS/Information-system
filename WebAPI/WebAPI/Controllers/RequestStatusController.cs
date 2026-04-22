using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RequestStatusController : ControllerBase
{
    private readonly IRequestStatusService _service;

    public RequestStatusController(IRequestStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var status = await _service.GetById(id);
        if (status == null) return NotFound();

        return Ok(status);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RequestStatus status)
    {
        var created = await _service.Create(status);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RequestStatus status)
    {
        if (!await _service.Update(id, status))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _service.Delete(id))
            return NotFound();

        return NoContent();
    }
}