using WebAPI.Models;

public interface IRequestService
{
    Task<IEnumerable<Request>> GetAll();
    Task<Request?> GetById(int id);
    Task<Request> Create(Request request);
    Task<bool> Update(int id, Request request);
    Task<bool> Delete(int id);
}