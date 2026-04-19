using WebAPI.Models;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAll();
    Task<Course?> GetById(int id);
    Task<Course> Create(Course course);
    Task<bool> Update(int id, Course course);
    Task<bool> Delete(int id);
}