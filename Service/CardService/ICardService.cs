using ResiPay.Model.Card;
using ResiPay.DB.Entities;
using System.Collections.Generic;

namespace ResiPay.Service.CardService
{
    public interface ICardService
    {
        public CardViewModel AddCard(CardInsertModel cardModel);
        public BaseResult<CardViewModel> GetCardByUserId(int userId);
        public CardViewModel UpdateCard(CardInsertModel cardModel);
        public BaseResult<CardViewModel> DeleteCard(string id);
        public BaseResult<CardViewModel> GetCardByCardId(string id);
        public List<CardViewModel> GetCards();


    }
}
