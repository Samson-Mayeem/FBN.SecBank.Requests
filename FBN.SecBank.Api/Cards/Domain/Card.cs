using System.ComponentModel.DataAnnotations;

namespace FBN.SecBank.Api.Cards.Domain
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public long Number { get; set; }
        public string CardType { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
