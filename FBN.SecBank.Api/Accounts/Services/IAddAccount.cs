using FBN.SecBank.Api.Accounts.Domain;

namespace FBN.SecBank.Api.Accounts.Services
{
    public interface IAddAccount
    {
        Task AddAccount(List<Account> accounts);
    }
}
