using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Accounts.Services.Iml
{
    public class DeleteAccountService : IDeleteAccount
    {
        private readonly SectBankContext _sectBankContext;

        public DeleteAccountService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }
        public async Task<Account> DeleteAccountAsync(Guid id)
        {
            var account = await _sectBankContext.accounts.FindAsync(id);
            if (account == null)
                return null;

            _sectBankContext.accounts.Remove(account);
            await _sectBankContext.SaveChangesAsync();

            return account;
        }
    }
}
