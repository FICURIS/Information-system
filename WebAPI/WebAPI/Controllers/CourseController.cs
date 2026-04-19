using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _service;

    public CourseController(ICourseService service)
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
        var course = await _service.GetById(id);
        if (course == null) return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        var created = await _service.Create(course);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Course course)
    {
        var updated = await _service.Update(id, course);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.Delete(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}