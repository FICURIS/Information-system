using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class UserService : IUserService
{
    private readonly TodoDb _db;

    public UserService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.User.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _db.User.FindAsync(id);
    }

    public async Task<User> Create(User user)
    {
        _db.User.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Update(int id, User input)
    {
        var user = await _db.User.FindAsync(id);
        if (user == null) return false;

        user.Login = input.Login;
        user.Email = input.Email;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _db.User.FindAsync(id);
        if (user == null) return false;

        _db.User.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }
}