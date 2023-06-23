using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Data;

namespace FBN.SecBank.Api.Accounts.Services.Iml
{
    public class EditAccountService : IEditAccounts
    {
        private readonly SectBankContext _sectBankContext;

        public EditAccountService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public Task<Account> PatchAccountAsync(Guid id, Dictionary<string, Account> updates)
        {
            var accountToUpdate = _sectBankContext.accounts.FirstOrDefault(a => a.AccId == id);

            if (accountToUpdate != null)
            {
                foreach (var update in updates)
                {
                    string propertyName = update.Key;
                    Account updatedAccount = update.Value;

                    var propertyInfo = typeof(Account).GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(accountToUpdate, propertyInfo.GetValue(updatedAccount));
                    }
                }

                // Save changes to the data context or repository
                _sectBankContext.SaveChanges();
            }

            return Task.FromResult(accountToUpdate);
        }

    }
}
