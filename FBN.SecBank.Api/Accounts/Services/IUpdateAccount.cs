using FBN.SecBank.Api.Accounts.Domain;

namespace FBN.SecBank.Api.Accounts.Services
{
    public interface IUpdateAccount
    {
        Task<Account> UpdateAccountAsync(  Account account);
    }
}