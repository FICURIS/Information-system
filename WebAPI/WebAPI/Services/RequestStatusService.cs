using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class RequestStatusService : IRequestStatusService
{
    private readonly TodoDb _db;

    public RequestStatusService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<RequestStatus>> GetAll()
    {
        return await _db.RequestStatus.ToListAsync();
    }

    public async Task<RequestStatus?> GetById(int id)
    {
        return await _db.RequestStatus.FindAsync(id);
    }

    public async Task<RequestStatus> Create(RequestStatus status)
    {
        _db.RequestStatus.Add(status);
        await _db.SaveChangesAsync();
        return status;
    }

    public async Task<bool> Update(int id, RequestStatus input)
    {
        var status = await _db.RequestStatus.FindAsync(id);
        if (status == null) return false;

        status.StatusName = input.StatusName;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var status = await _db.RequestStatus.FindAsync(id);
        if (status == null) return false;

        _db.RequestStatus.Remove(status);
        await _db.SaveChangesAsync();
        return true;
    }
}