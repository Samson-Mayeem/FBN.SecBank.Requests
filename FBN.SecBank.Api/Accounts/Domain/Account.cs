using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace FBN.SecBank.Api.Accounts.Domain
{
    public class Account
    {
        [Key]
        public Guid AccId { get; set; }
        [Unique]
        public long AccountNumber { get; set; }
        public Decimal InialAmount { get; set; }
        public DateTime DateCreatedAt { get; set; }
    }
}
