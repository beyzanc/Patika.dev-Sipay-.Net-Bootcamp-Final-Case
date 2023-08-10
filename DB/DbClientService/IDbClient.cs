using MongoDB.Driver;
using ResiPay.DB.Entities;

namespace ResiPay.DB.DbClientService;

public interface IDbClient
    {
        IMongoCollection<Card> GetCreditCardCollection();

    }

