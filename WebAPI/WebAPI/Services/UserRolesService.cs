using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class UserRolesService : IUserRolesService
{
    private readonly TodoDb _db;

    public UserRolesService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserRoles>> GetAll()
    {
        return await _db.UserRoles.ToListAsync();
    }

    public async Task<IEnumerable<UserRoles>> GetByUserId(int userId)
    {
        return await _db.UserRoles
            .Where(ur => ur.UserID == userId)
            .ToListAsync();
    }

    public async Task<UserRoles?> GetById(int id)
    {
        return await _db.UserRoles.FindAsync(id);
    }

    public async Task<UserRoles> AssignRole(UserRoles userRole)
    {
        var userExists = await _db.User.AnyAsync(u => u.UserID == userRole.UserID);
        var roleExists = await _db.Role.AnyAsync(r => r.RoleID == userRole.RoleID);

        if (!userExists || !roleExists)
            throw new Exception("Invalid UserID or RoleID");

        var alreadyExists = await _db.UserRoles.AnyAsync(ur =>
            ur.UserID == userRole.UserID &&
            ur.RoleID == userRole.RoleID);

        if (alreadyExists)
            throw new Exception("User already has this role");

        _db.UserRoles.Add(userRole);
        await _db.SaveChangesAsync();

        return userRole;
    }

    public async Task<bool> RemoveRole(int id)
    {
        var userRole = await _db.UserRoles.FindAsync(id);
        if (userRole == null) return false;

        _db.UserRoles.Remove(userRole);
        await _db.SaveChangesAsync();

        return true;
    }
}