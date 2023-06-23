using FBN.SecBank.Api.Accounts.Domain;

namespace FBN.SecBank.Api.Accounts.Services
{
    public interface IGetAccount
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountById(Guid id);
        Task<List<Account>> GetAccountByDateAsync(DateTime dateTime);
        Task<List<Account>> GetByAccountNumberAsync(long acc_num);
    }
}
