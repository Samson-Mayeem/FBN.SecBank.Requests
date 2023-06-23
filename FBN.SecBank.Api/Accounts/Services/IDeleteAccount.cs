using FBN.SecBank.Api.Accounts.Domain;

namespace FBN.SecBank.Api.Accounts.Services
{
    public interface IDeleteAccount
    {
        Task<Account> DeleteAccountAsync(Guid id);
    }
}
