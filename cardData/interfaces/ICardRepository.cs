using cardData.Models;

namespace cardData.interfaces
{
    public interface ICardRepository
    {
        ICollection<Card> GetCards();
        bool CreateCard(Card card);
        bool Save();

    }
}
