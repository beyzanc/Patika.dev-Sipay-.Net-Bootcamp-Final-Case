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
using ResiPay.DB;

namespace ResiPay.Service.CardService;

public class CardService : ICardService
{

    private readonly IMongoCollection<Card> _cards;
    private readonly IMapper _mapper;
    private readonly ResiPayDbContext _dbContext;


    public CardService(IDbClient dbClient, IMapper mapper, ResiPayDbContext dbContext)
    {
        _cards = (IMongoCollection<Card>)dbClient.GetCreditCardCollection();
        _mapper = mapper;
        _dbContext = dbContext;

    }

    public BaseResult<CardViewModel> AddCard(CardInsertModel cardModel)
    {
        var result = new BaseResult<CardViewModel>();

        try
        {
            var user = _dbContext.User
                .Where(u => u.Id == cardModel.UserId)
                .FirstOrDefault();

            if (user is null)
            {
                result.IsSuccess = false;
                result.Message = "User not found with given user ID to add card.";
                return result;

            }

            var apartment = _dbContext.Apartment
                .Where(u => u.Id == cardModel.ApartmentId)
                .FirstOrDefault();

            if (apartment is null)
            {
                result.IsSuccess = false;
                result.Message = "Apartment not found with given apartment ID to add card.";
                return result;

            }

            var cardEntity = _mapper.Map<ResiPay.DB.Entities.Card>(cardModel);

            _cards.InsertOne(cardEntity);

            var cardViewModel = _mapper.Map<CardViewModel>(cardEntity);

            result.IsSuccess = true;
            result.Data = cardViewModel;
            result.Message = "Card added successfully.";

        }
        catch (Exception ex)
        {
            result.IsSuccess = false;
            result.Message = "An error occurred while adding the card.";

        }

        return result;
    }


    public BaseResult<CardViewModel> GetCardByUserId(int userId)
    {
        var result = new BaseResult<CardViewModel>();

        var card = _cards
            .Find(card => card.UserId == userId)
            .FirstOrDefault();
        if (card != null)
        {
            result.IsSuccess = true;
            result.Data = _mapper.Map<CardViewModel>(card);
            result.Message = "Card retrieved successfully.";

        }
        else
        {
            result.IsSuccess = false;
            result.Message = "Card not found with the provided user ID.";

        }

        return result;

    }

    public BaseResult<CardViewModel> UpdateCard(CardInsertModel cardModel)
    {
        var result = new BaseResult<CardViewModel>();

        try
        {
            var user = _dbContext.User
                .Where(u => u.Id == cardModel.UserId)
                .FirstOrDefault();

            if (user is null)
            {
                result.IsSuccess = false;
                result.Message = "User not found with given user ID to add card.";
                return result;

            }

            var apartment = _dbContext.Apartment
                .Where(u => u.Id == cardModel.ApartmentId)
                .FirstOrDefault();

            if (apartment is null)
            {
                result.IsSuccess = false;
                result.Message = "Apartment not found with given apartment ID to add card.";
                return result;

            }

            var existingCard = GetCardByCardId(cardModel.Id);

            if (existingCard.IsSuccess) 
            {
                var cardEntity = _mapper.Map<ResiPay.DB.Entities.Card>(cardModel);

                var filter = Builders<ResiPay.DB.Entities.Card>.Filter.Eq(c => c.Id, cardModel.Id);
                _cards.ReplaceOne(filter, cardEntity);

                var updatedCardViewModel = _mapper.Map<CardViewModel>(cardEntity);

                result.IsSuccess = true;
                result.Data = updatedCardViewModel;
                result.Message = "Card updated successfully.";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Card not found.";

            }
        }
        catch (Exception e)
        {
            result.IsSuccess = false;
            result.Message = "An error occurred while updating the card.";

        }

        return result;

    }


    public BaseResult<CardViewModel> DeleteCard(string id)
    {
        var result = new BaseResult<CardViewModel>();

        try
        {
            var deletedCard = _cards
                .FindOneAndDelete(card => card.Id == id);

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

        if (id.Length != 24 || !System.Text.RegularExpressions.Regex.IsMatch(id, @"^[0-9a-fA-F]+$"))
        {
            result.Message = "Invalid ID format. ID should be a valid 24-character hexadecimal string.";
            return result;

        }

        var card = _cards
            .Find(card => card.Id == id)
            .FirstOrDefault();

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

    public BaseResult<List<CardViewModel>> GetCards()
    {
        var result = new BaseResult<List<CardViewModel>>();

        var cards = _cards
            .Find(card => true)
            .ToList();

        if (cards.Count == 0)
        {
            result.Message = "No cards found.";
            return result;

        }

        result.IsSuccess = true;
        result.Data = _mapper.Map<List<CardViewModel>>(cards);
        result.Message = "Cards listed successfully.";

        return result;

    }
}
