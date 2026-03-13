using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly TodoDb _db;

        public CourseController(TodoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            return await _db.Course.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course = await _db.Course.FindAsync(id);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(Course course)
        {
            _db.Course.Add(course);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = course.CourseID }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Course inputCourse)
        {
            var course = await _db.Course.FindAsync(id);

            if (course == null)
                return NotFound();

            course.CourseName = inputCourse.CourseName;
            course.StartDate = inputCourse.StartDate;
            course.EndDate = inputCourse.EndDate;
            course.Description = inputCourse.Description;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _db.Course.FindAsync(id);

            if (course == null)
                return NotFound();

            _db.Course.Remove(course);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}