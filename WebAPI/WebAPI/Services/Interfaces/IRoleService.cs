using WebAPI.Models;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAll();
    Task<Role?> GetById(int id);
    Task<Role> Create(Role role);
    Task<bool> Update(int id, Role role);
    Task<bool> Delete(int id);
}