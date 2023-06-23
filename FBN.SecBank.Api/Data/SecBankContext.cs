using FBN.SecBank.Api.Accounts.Domain;
using FBN.SecBank.Api.Cards.Domain;
using FBN.SecBank.Api.Customers.Domain;
using FBN.SecBank.Api.Requests.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FBN.SecBank.Api.Data
{
    public class SectBankContext : DbContext
    {
        public SectBankContext(DbContextOptions<SectBankContext> options) : base(options) { }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Request> requests { get; set; }
        public DbSet<Card> cards { get; set; }


    }
}
