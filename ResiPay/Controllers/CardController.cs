using Microsoft.AspNetCore.Mvc;
using ResiPay.DB.Entities;
using ResiPay.Model.Card;
using ResiPay.Service.CardService;
using System.Collections.Generic;


namespace ResiPay.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;

    }


    [HttpGet]
    public List<CardViewModel> GetCards()
    {
        return _cardService.GetCards();
    }

    [HttpGet("ByCardId/{id}")]
    public BaseResult<CardViewModel> GetCardByCardId(string id)
    {
        return _cardService.GetCardByCardId(id);
    }

    [HttpGet("ByUserId/{id}")]
    public BaseResult<CardViewModel> GetCardByUserId(int userId)
    {
        return _cardService.GetCardByUserId(userId);
    }

    [HttpPost]
    public CardViewModel AddCard(CardInsertModel cardModel)
    {
        return _cardService.AddCard(cardModel);
    }

    [HttpDelete("{id}")]
    public BaseResult<CardViewModel> DeleteCard(string id)
    {
        return _cardService.DeleteCard(id);
    }

    [HttpPut]
    public CardViewModel UpdateCard(CardInsertModel cardModel)
    {
        return _cardService.UpdateCard(cardModel);
    }

}
