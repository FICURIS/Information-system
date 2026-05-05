using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class CourseService : ICourseService
{
    private readonly TodoDb _db;

    public CourseService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _db.Course.ToListAsync();
    }

    public async Task<Course?> GetById(int id)
    {
        return await _db.Course.FindAsync(id);
    }

    public async Task<Course> Create(Course course)
    {
        try
        {
            _db.Course.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<bool> Update(int id, Course input)
    {
        var course = await _db.Course.FindAsync(id);
        if (course == null) return false;

        course.CourseName = input.CourseName;
        course.Description = input.Description;
        course.StartDate = input.StartDate;
        course.EndDate = input.EndDate;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var course = await _db.Course.FindAsync(id);
        if (course == null) return false;

        _db.Course.Remove(course);
        await _db.SaveChangesAsync();
        return true;
    }
}