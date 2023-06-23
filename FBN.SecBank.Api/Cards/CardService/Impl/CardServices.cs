using FBN.SecBank.Api.Cards.Domain;
using FBN.SecBank.Api.Customers.Domain;
using FBN.SecBank.Api.Customers.Services;
using FBN.SecBank.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FBN.SecBank.Api.Cards.CardService.Impl
{
    public class CardService : ICardService
    {
        private readonly SectBankContext _sectBankContext;

        public CardService(SectBankContext sectBankContext)
        {
            _sectBankContext = sectBankContext;
        }

        public async Task AddCards(List<Card> cards)
        {
            _sectBankContext.cards.AddRange(cards);
            await _sectBankContext.SaveChangesAsync();
        }

        public async Task<List<Card>> GetAllCardAsync()
        {
            return await _sectBankContext.cards.ToListAsync();
        }

        public async Task<Card> GetCardById(Guid id)
        {
            return await _sectBankContext.cards.FindAsync(id);
        }

        public async Task<Card> DeleteCardAsync(Guid id)
        {
            var card = await _sectBankContext.cards.FindAsync(id);
            if (card == null)
                return null;

            _sectBankContext.cards.Remove(card);
            await _sectBankContext.SaveChangesAsync();

            return card;
        }

        public async Task<Card> UpdateCardAsync(Card card)
        {
            _sectBankContext.cards.Update(card);
            await _sectBankContext.SaveChangesAsync();

            return card;
        }

        public async Task<Card> PatchCardAsync(Guid id, Dictionary<string, Card> updates)
        {
            var card = await _sectBankContext.cards.FindAsync(id);
            if (card == null)
                return null;

            foreach (var update in updates)
            {
                switch (update.Key)
                {
                    case "CardNumber":
                        card.Number = update.Value.Number;
                        break;
                    case "CardType":
                        card.CardType = update.Value.CardType;
                        break;
                    case "ExpiryDate":
                        card.ExpiryDate = update.Value.ExpiryDate;
                        break;
                }
            }
            await _sectBankContext.SaveChangesAsync();
            return card;
        }
    }
}
