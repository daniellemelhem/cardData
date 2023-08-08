using cardData.Data;
using cardData.interfaces;
using cardData.Models;

namespace cardData.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;

        public CardRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateCard(Card card)
        {
            _context.Add(card);
            return Save();
        }

        public ICollection<Card> GetCards()
        {
            return _context.Cards.ToList();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }
    }
}
