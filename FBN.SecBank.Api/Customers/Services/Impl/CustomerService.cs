using FBN.SecBank.Api.Customers.Domain;
using FBN.SecBank.Api.Data;
using FBN.SecBank.Api.Requests.Domain;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Customers.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly SectBankContext _sectBankContext;

        public CustomerService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public async Task AddCustomer(List<Customer> customers)
        {
            _sectBankContext.customers.AddRange(customers);
            await _sectBankContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _sectBankContext.customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _sectBankContext.customers.FindAsync(id);
        }

     

       

        public async Task<Customer> DeleteCustomerAsync(Guid id)
        {
            var customer = await _sectBankContext.customers.FindAsync(id);
            if (customer == null)
                return null;

            _sectBankContext.customers.Remove(customer);
            await _sectBankContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _sectBankContext.customers.Update(customer);
            await _sectBankContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> PatchCustomerAsync(Guid id, Dictionary<string, Customer> updates)
        {
            var customer = await _sectBankContext.customers.FindAsync(id);
            if (customer == null)
                return null;

            foreach (var update in updates)
            {
                switch (update.Key)
                {
                    case "FirstName":
                        customer.FirstName = update.Value.FirstName;
                        break;
                    case "LastName":
                        customer.LastName = update.Value.LastName;
                        break;
                    case "Email":
                        customer.Email = update.Value.Email;
                        break;
                    case "Phone":
                        customer.Phone = update.Value.Phone;
                        break;
                    case "Address":
                        customer.Address = update.Value.Address;
                        break;
                }
            }
            await _sectBankContext.SaveChangesAsync();
            return customer;
        }
    }
}