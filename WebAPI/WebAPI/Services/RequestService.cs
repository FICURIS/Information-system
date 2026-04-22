using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class RequestService : IRequestService
{
    private readonly TodoDb _db;

    public RequestService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Request>> GetAll()
    {
        return await _db.Request
            .Include(r => r.User)
            .Include(r => r.Course)
            .Include(r => r.Status)
            .ToListAsync();
    }

    public async Task<Request?> GetById(int id)
    {
        return await _db.Request
            .Include(r => r.User)
            .Include(r => r.Course)
            .Include(r => r.Status)
            .FirstOrDefaultAsync(r => r.RequestID == id);
    }

    public async Task<Request> Create(Request request)
    {
        request.CreatedDate = DateTime.UtcNow;

        _db.Request.Add(request);
        await _db.SaveChangesAsync();

        return request;
    }

    public async Task<bool> Update(int id, Request input)
    {
        var request = await _db.Request.FindAsync(id);
        if (request == null) return false;

        request.UserID = input.UserID;
        request.CourseID = input.CourseID;
        request.StatusID = input.StatusID;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var request = await _db.Request.FindAsync(id);
        if (request == null) return false;

        _db.Request.Remove(request);
        await _db.SaveChangesAsync();
        return true;
    }
}