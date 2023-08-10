using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.DB.Entities;
using ResiPay.Model.Card;
using ResiPay.Service.CardService;
using System.Collections.Generic;
using System.Data;


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
    [Authorize(Roles = "Admin")]
    public BaseResult<List<CardViewModel>> GetCards()
    {
        return _cardService.GetCards();

    }

    [HttpGet("ByCardId/{id}")]
    [Authorize(Roles = "Admin")]
    public BaseResult<CardViewModel> GetCardByCardId(string id)
    {
        return _cardService.GetCardByCardId(id);

    }

    [HttpGet("ByUserId/{userId}")]
    [Authorize(Roles = "Admin, Resident")]
    public BaseResult<CardViewModel> GetCardByUserId(int userId)
    {
        return _cardService.GetCardByUserId(userId);

    }

    [HttpPost]
    [Authorize(Roles = "Admin, Resident")]
    public BaseResult<CardViewModel> AddCard(CardInsertModel cardModel)
    {
        return _cardService.AddCard(cardModel);

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Resident")]
    public BaseResult<CardViewModel> DeleteCard(string id)
    {
        return _cardService.DeleteCard(id);

    }

    [HttpPut]
    [Authorize(Roles = "Admin, Resident")]
    public BaseResult<CardViewModel> UpdateCard(CardInsertModel cardModel)
    {
        return _cardService.UpdateCard(cardModel);

    }

}
