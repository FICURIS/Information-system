using WebAPI.Models;

public interface IUserEnrollmentService
{
    Task<IEnumerable<UserEnrollment>> GetAll();
    Task<IEnumerable<UserEnrollment>> GetByUserId(int userId);
    Task<UserEnrollment?> GetById(int id);
    Task<UserEnrollment> Create(UserEnrollment enrollment);
    Task<bool> Delete(int id);
}