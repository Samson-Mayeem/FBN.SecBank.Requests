using System.ComponentModel.DataAnnotations;

namespace FBN.SecBank.Api.Customers.Domain
{
    public class Customer
    {
        [Key]
        public Guid CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
