using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ResiPay.DB.Entities;
using ResiPay.DB.DbConfigurations.CardConfig;

namespace ResiPay.DB.DbClientService;

public class DbClient : IDbClient
{
    private readonly IMongoCollection<Card> _cards;
    public DbClient(IOptions<CardConfig> configuration)
    {
        var client = new MongoClient(configuration.Value.Connection_String);
        var database = client.GetDatabase(configuration.Value.Database_Name);
        _cards = database.GetCollection<Card>(configuration.Value.Cards_Collection_Name);

    }

    public IMongoCollection<Card> GetCreditCardCollection()
    {
        return _cards;

    }
}
