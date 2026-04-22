using WebAPI.Models;

public interface IPhoneNumberService
{
    Task<IEnumerable<PhoneNumber>> GetAll();
    Task<IEnumerable<PhoneNumber>> GetByUserId(int userId);
    Task<PhoneNumber?> GetById(int id);
    Task<PhoneNumber> Create(PhoneNumber phone);
    Task<bool> Delete(int id);
}