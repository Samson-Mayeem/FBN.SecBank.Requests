using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;

namespace FBN.SecBank.Api.Accounts.Services.Iml
{
    public class AddAccountService : IAddAccount
    {
        private readonly SectBankContext _sectBankContext;

        public AddAccountService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public async Task AddAccount(List<Account> accounts)
        {
            _sectBankContext.AddRange(accounts);
            await _sectBankContext.SaveChangesAsync();
        }
    }
}
