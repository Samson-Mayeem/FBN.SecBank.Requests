using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;
using FBN.SecBank.Api.Requests.Domain;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Requests.RequestService.Impl
{
    public class RequestServices : IRequestServices
    {
        private readonly SectBankContext _sectBankContext;

        public RequestServices(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public async Task AddAccount(List<Request> requests)
        {
            _sectBankContext.AddRange(requests);
            await _sectBankContext.SaveChangesAsync();
        }

        public async Task<Request> DeleteRequestAsync(Guid id)
        {
            var request = await _sectBankContext.requests.FindAsync(id);
            if (request == null)
                return null;

            _sectBankContext.requests.Remove(request);
            await _sectBankContext.SaveChangesAsync();

            return request;
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _sectBankContext.requests.ToListAsync();
        }

        public async Task<List<Request>> GetByRequestStatusAsync(bool status)
        {
            return await _sectBankContext.requests.Where(r => r.RequestStatus == status).ToListAsync();
        }

        public async Task<List<Request>> GetRequestByDateAsync(DateTime dateTime)
        {
            return await _sectBankContext.requests.Where(r => r.RequestDate == dateTime).ToListAsync();
        }

        public async Task<Request> GetRequestById(Guid id)
        {
            return await _sectBankContext.requests.FindAsync(id);
        }
        public async Task<Request> UpdateRequestAsync(Request request)
        {
            _sectBankContext.Entry(request).State = EntityState.Modified;
            await _sectBankContext.SaveChangesAsync();
            return request;
        }

        public async Task<Request> PatchRequestAsync(Guid id, Dictionary<string, Request> updates)
        {
            var request = await _sectBankContext.requests.FindAsync(id);
            if (request == null)
                return null;

            foreach (var update in updates)
            {
                switch (update.Key)
                {
                    case "Status":
                        request.RequestStatus = update.Value.RequestStatus;
                        break;
                    case "Date":
                        request.RequestDate = update.Value.RequestDate;
                        break;
                }
            }

            await _sectBankContext.SaveChangesAsync();

            return request;
        }
    }
}
