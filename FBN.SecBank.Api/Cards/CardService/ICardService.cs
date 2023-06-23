using FBN.SecBank.Api.Cards.Domain;
using FBN.SecBank.Api.Customers.Domain;

namespace FBN.SecBank.Api.Cards.CardService
{
    public interface ICardService
    {
        Task AddCards(List<Card> cards);
        Task<List<Card>> GetAllCardAsync();
        Task<Card> GetCardById(Guid id);
        Task<Card> DeleteCardAsync(Guid id);
        Task<Card> UpdateCardAsync(Card request);
        Task<Card> PatchCardAsync(Guid id, Dictionary<string, Card> updates);
    }
}
