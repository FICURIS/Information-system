using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class RoleService : IRoleService
{
    private readonly TodoDb _db;

    public RoleService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _db.Role.ToListAsync();
    }

    public async Task<Role?> GetById(int id)
    {
        return await _db.Role.FindAsync(id);
    }

    public async Task<Role> Create(Role role)
    {
        _db.Role.Add(role);
        await _db.SaveChangesAsync();
        return role;
    }

    public async Task<bool> Update(int id, Role input)
    {
        var role = await _db.Role.FindAsync(id);
        if (role == null) return false;

        role.RoleName = input.RoleName;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var role = await _db.Role.FindAsync(id);
        if (role == null) return false;

        var isUsed = await _db.UserRoles.AnyAsync(ur => ur.RoleID == id);
        if (isUsed)
            throw new Exception("Role is used by users");

        _db.Role.Remove(role);
        await _db.SaveChangesAsync();
        return true;
    }
}