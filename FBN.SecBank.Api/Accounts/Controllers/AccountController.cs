using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Accounts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FBN.SecBank.Api.Accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDeleteAccount _deleteAccount;
        private readonly IGetAccount _getAccount;
        private readonly IUpdateAccount _updateAccount;
        private readonly IAddAccount _addAccount;
        public AccountController(
            IDeleteAccount deleteAccount,
            IUpdateAccount updateAccount,
            IAddAccount addAccount,
            IGetAccount getAccount)
        {
            _deleteAccount = deleteAccount;
            _updateAccount = updateAccount;
            _addAccount = addAccount;
            _getAccount = getAccount;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(List<Account> account)
        {
            await _addAccount.AddAccount(account);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var appointments = await _getAccount.GetAllAccountsAsync();
            return Ok(appointments);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetByAccountDate(DateTime dateTime)
        {
            var appointments = await _getAccount.GetAccountByDateAsync(dateTime);
            return Ok(appointments);
        }

        [HttpGet("/{acc_num}")]
        public async Task<IActionResult> GetByAccountNumber(long acc_num)
        {
            var appointments = await _getAccount.GetByAccountNumberAsync(acc_num);
            return Ok(appointments);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, Account req)
        {
            var find_acc = await _getAccount.GetAccountById(id);
            if (find_acc == null)
            {
                return NotFound();
            }

            var updatedAccount = await _updateAccount.UpdateAccountAsync(req);
            if (updatedAccount == null)
            {
                return NotFound();
            }

            return Ok(updatedAccount);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var acc = await _deleteAccount.DeleteAccountAsync(id);

            if (acc == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPatch("Edit/{id}")]
        public async Task<IActionResult> AddAccount(Guid accid, List<Account> accounts)
        {
            // Retrieve the existing account by its ID
            var existingAccount = await _getAccount.GetAccountById(accid);
            if (existingAccount == null)
            {
                return NotFound(); // Return 404 Not Found if the account doesn't exist
            }

            // Update the existing account with the provided data
            existingAccount.AccountNumber = accounts[0].AccountNumber;
            existingAccount.InialAmount = accounts[0].InialAmount;
            existingAccount.DateCreatedAt = accounts[0].DateCreatedAt;

            // Save the updated account
            await _addAccount.AddAccount(accounts);

            return Ok();
        }
    }
}
