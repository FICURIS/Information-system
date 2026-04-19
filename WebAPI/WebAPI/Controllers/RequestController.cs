using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IRequestService _service;

    public RequestController(IRequestService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.GetById(id);
        if (item == null) return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Request request)
    {
        var created = await _service.Create(request);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Request request)
    {
        if (!await _service.Update(id, request))
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