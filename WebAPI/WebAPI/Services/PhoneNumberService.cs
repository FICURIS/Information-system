using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class PhoneNumberService : IPhoneNumberService
{
    private readonly TodoDb _db;

    public PhoneNumberService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PhoneNumber>> GetAll()
    {
        return await _db.PhoneNumber.ToListAsync();
    }

    public async Task<IEnumerable<PhoneNumber>> GetByUserId(int userId)
    {
        return await _db.PhoneNumber
            .Where(p => p.UserID == userId)
            .ToListAsync();
    }

    public async Task<PhoneNumber?> GetById(int id)
    {
        return await _db.PhoneNumber.FindAsync(id);
    }

    public async Task<PhoneNumber> Create(PhoneNumber phone)
    {
        var userExists = await _db.User.AnyAsync(u => u.UserID == phone.UserID);
        if (!userExists)
            throw new Exception("User not found");

        _db.PhoneNumber.Add(phone);
        await _db.SaveChangesAsync();
        return phone;
    }

    public async Task<bool> Delete(int id)
    {
        var phone = await _db.PhoneNumber.FindAsync(id);
        if (phone == null) return false;

        _db.PhoneNumber.Remove(phone);
        await _db.SaveChangesAsync();
        return true;
    }
}