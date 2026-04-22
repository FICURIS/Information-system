using WebAPI.Models;

public interface IRequestStatusService
{
    Task<IEnumerable<RequestStatus>> GetAll();
    Task<RequestStatus?> GetById(int id);
    Task<RequestStatus> Create(RequestStatus status);
    Task<bool> Update(int id, RequestStatus status);
    Task<bool> Delete(int id);
}