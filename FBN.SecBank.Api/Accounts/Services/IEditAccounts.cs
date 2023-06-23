using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Cards.Domain;

namespace FBN.SecBank.Api.Accounts.Services
{
    public interface IEditAccounts
    {
        Task<Account> PatchAccountAsync(Guid id, Dictionary<string, Account> updates);

    }
}
