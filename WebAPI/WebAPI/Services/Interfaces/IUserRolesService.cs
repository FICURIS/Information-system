using WebAPI.Models;

public interface IUserRolesService
{
    Task<IEnumerable<UserRoles>> GetAll();
    Task<IEnumerable<UserRoles>> GetByUserId(int userId);
    Task<UserRoles?> GetById(int id);
    Task<UserRoles> AssignRole(UserRoles userRole);
    Task<bool> RemoveRole(int id);
}