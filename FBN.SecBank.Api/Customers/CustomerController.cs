using FBN.SecBank.Api.Customers.Domain;
using FBN.SecBank.Api.Customers.Services;
using Microsoft.AspNetCore.Mvc;

namespace FBN.SecBank.Api.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(List<Customer> customers)
        {
            await _customerService.AddCustomer(customers);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomerAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

       

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _customerService.DeleteCustomerAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, Customer customer)
        {
            if (id != customer.CustId)
                return BadRequest();

            var updatedCustomer = await _customerService.UpdateCustomerAsync(customer);
            return Ok(updatedCustomer);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCustomer(Guid id, Dictionary<string, Customer> updates)
        {
            var patchedCustomer = await _customerService.PatchCustomerAsync(id, updates);
            if (patchedCustomer == null)
                return NotFound();

            return Ok(patchedCustomer);
        }
    }
}

