using WebAPI.Models;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<User> Create(User user);
    Task<bool> Update(int id, User user);
    Task<bool> Delete(int id);
}