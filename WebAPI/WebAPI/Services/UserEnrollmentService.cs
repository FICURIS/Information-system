using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class UserEnrollmentService : IUserEnrollmentService
{
    private readonly TodoDb _db;

    public UserEnrollmentService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserEnrollment>> GetAll()
    {
        return await _db.UserEnrollment.ToListAsync();
    }

    public async Task<IEnumerable<UserEnrollment>> GetByUserId(int userId)
    {
        return await _db.UserEnrollment
            .Where(e => e.UserID == userId)
            .ToListAsync();
    }

    public async Task<UserEnrollment?> GetById(int id)
    {
        return await _db.UserEnrollment.FindAsync(id);
    }

    public async Task<UserEnrollment> Create(UserEnrollment enrollment)
    {
        var userExists = await _db.User.AnyAsync(u => u.UserID == enrollment.UserID);
        var courseExists = await _db.Course.AnyAsync(c => c.CourseID == enrollment.CourseID);
        var requestExists = await _db.Request.AnyAsync(r => r.RequestID == enrollment.RequestID);

        if (!userExists || !courseExists || !requestExists)
            throw new Exception("Invalid foreign keys");

        var alreadyExists = await _db.UserEnrollment.AnyAsync(e =>
            e.UserID == enrollment.UserID &&
            e.CourseID == enrollment.CourseID);

        if (alreadyExists)
            throw new Exception("User already enrolled in this course");

        enrollment.EnrollDate = DateTime.UtcNow;

        _db.UserEnrollment.Add(enrollment);
        await _db.SaveChangesAsync();

        return enrollment;
    }

    public async Task<bool> Delete(int id)
    {
        var enrollment = await _db.UserEnrollment.FindAsync(id);
        if (enrollment == null) return false;

        _db.UserEnrollment.Remove(enrollment);
        await _db.SaveChangesAsync();

        return true;
    }
}