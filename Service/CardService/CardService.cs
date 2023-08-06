using AutoMapper;
using MongoDB.Driver;
using ResiPay.DB.Entities;
using ResiPay.Model.Card;
using System;
using System.Collections.Generic;
using ResiPay.DB.Entities;
using ResiPay.DB.DbClientService;
using Card = ResiPay.DB.Entities.Card;
using System.Linq;

namespace ResiPay.Service.CardService;

public class CardService : ICardService
{

    private readonly IMongoCollection<Card> _cards;
    private readonly IMapper _mapper;

    public CardService(IDbClient dbClient, IMapper mapper)
    {
        _cards = (IMongoCollection<Card>)dbClient.GetCreditCardCollection();
        _mapper = mapper;
    }

    public CardViewModel AddCard(CardInsertModel cardModel)
    {
        var cardEntity = _mapper.Map<ResiPay.DB.Entities.Card>(cardModel);
        _cards.InsertOne(cardEntity);

        var cardViewModel = _mapper.Map<CardViewModel>(cardEntity);

        return cardViewModel;
    }

    public BaseResult<CardViewModel> GetCardByUserId(int userId)
    {
        var result = new BaseResult<CardViewModel>();
        var cards = GetCards();
        var card = cards.FirstOrDefault(c => c.UserId == userId);

        if (card != null)
        {
            result.IsSuccess = true;
            result.Data = _mapper.Map<CardViewModel>(card);
            result.Message = "Card retrieved successfully.";
        }
        else
        {
            result.Message = "Card not found with given User ID.";
        }

        return result;
    }


    public CardViewModel UpdateCard(CardInsertModel cardModel)
    {
        var existingCard = GetCardByCardId(cardModel.Id);
        var cardEntity = _mapper.Map<ResiPay.DB.Entities.Card>(cardModel);

        _cards.ReplaceOne(c => c.Id == cardModel.Id, cardEntity);

        var cardViewModel = _mapper.Map<CardViewModel>(cardModel);
        return cardViewModel;
    }

    public BaseResult<CardViewModel> DeleteCard(string id)
    {
        var result = new BaseResult<CardViewModel>();
        try
        {
            var deletedCard = _cards.FindOneAndDelete(card => card.Id == id);
            if (deletedCard != null)
            {
                result.IsSuccess = true;
                result.Message = "Card is deleted successfully.";
            }
            else
            {
                result.Message = "Card not found with given ID.";
            }
        }
        catch (Exception)
        {
            result.Message = "Provide a valid ID to delete.";
        }

        return result;
    }

    public BaseResult<CardViewModel> GetCardByCardId(string id)
    {
        var result = new BaseResult<CardViewModel>();
        if (id.Length != 24)
        {
            result.Message = "Invalid ID format. ID should be 24 digits numeric.";
            return result;
        }

        var card = _cards.Find(card => card.Id == id).FirstOrDefault();
        if (card != null)
        {
            result.IsSuccess = true;
            result.Data = _mapper.Map<CardViewModel>(card);
            result.Message = "Card retrieved successfully.";
        }
        else
        {
            result.Message = "Card not found with the provided ID.";
        }

        return result;
    }


    public List<CardViewModel> GetCards()
    {
        var cards = _cards.Find(card => true).ToList();
        return _mapper.Map<List<CardViewModel>>(cards);
    }

}
