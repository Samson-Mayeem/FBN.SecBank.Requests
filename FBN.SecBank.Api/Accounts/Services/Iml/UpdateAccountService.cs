using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Accounts.Services.Iml
{
    public class UpdateAccountService : IUpdateAccount
    {
        private readonly SectBankContext _sectBankContext;

        public UpdateAccountService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public async Task<Account> UpdateAccountAsync(Account req)
        {
            var account = await _sectBankContext.accounts.FirstOrDefaultAsync(a => a.AccId == req.AccId);
            if (account == null)
            {
                return null; // or throw an exception indicating the account was not found
            }

            if (account.AccountNumber != req.AccountNumber)
            {
                account.AccountNumber = req.AccountNumber;
            }

            if (account.InialAmount != req.InialAmount)
            {
                account.InialAmount = req.InialAmount;
            }

            if (account.DateCreatedAt != req.DateCreatedAt)
            {
                account.DateCreatedAt = req.DateCreatedAt;
            }

            if (_sectBankContext.ChangeTracker.HasChanges())
            {
                await _sectBankContext.SaveChangesAsync();
            }

            return account;
        }



    }
}
