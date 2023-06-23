
using FBN.SecBank.Api.Requests.Domain;

namespace FBN.SecBank.Api.Requests.RequestService
{
    public interface IRequestServices
    {
        Task AddAccount(List<Request> requests);
        Task<List<Request>> GetAllRequestsAsync();
        Task<Request> GetRequestById(Guid id);
        Task<List<Request>> GetRequestByDateAsync(DateTime dateTime);
        Task<List<Request>> GetByRequestStatusAsync(bool status);
        Task<Request> DeleteRequestAsync(Guid id);
        Task<Request> UpdateRequestAsync(Request request);
        Task<Request> PatchRequestAsync(Guid id, Dictionary<string, Request> updates);
    }
}
