using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Accounts.Services.Iml
{
    public class GetAccountService : IGetAccount
    {
        private readonly SectBankContext _sectBankContext;

        public GetAccountService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _sectBankContext.accounts.ToListAsync();
        }
        public async Task<Account> GetAccountById(Guid guid)
        {
            var acc = await _sectBankContext.accounts.Where(a => a.Equals(guid)).FirstOrDefaultAsync();
            return acc;
        }
        public async Task<List<Account>> GetByAccountNumberAsync(long accountNumber)
        {
            return await _sectBankContext.accounts.Where(a => a.AccountNumber.Equals(accountNumber)).ToListAsync();
        }
        public async Task<List<Account>> GetAccountByDateAsync(DateTime dateTime)
        {
            DateTime dateOnly = dateTime.Date; // Extract only the date component

            return await _sectBankContext.accounts
                .Where(a => a.DateCreatedAt.Date.Equals(dateOnly))
                .ToListAsync();
        }


    }
}
