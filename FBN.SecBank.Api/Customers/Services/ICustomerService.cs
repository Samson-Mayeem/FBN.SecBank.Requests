using FBN.SecBank.Api.Customers.Domain;

namespace FBN.SecBank.Api.Customers.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(List<Customer> customer);
        Task<List<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> DeleteCustomerAsync(Guid id);
        Task<Customer> UpdateCustomerAsync(Customer request);
        Task<Customer> PatchCustomerAsync(Guid id, Dictionary<string, Customer> updates);
    }
}
