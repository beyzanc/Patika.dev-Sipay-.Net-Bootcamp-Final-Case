using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ResiPay.Model.Card;

public class CardInsertModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("card_number")]
    public string CardNumber { get; set; }

    [BsonElement("cvc")]
    public string CVC { get; set; }

    [BsonElement("card_date")]
    public string Date { get; set; }

    [BsonElement("user_id")]
    public int UserId { get; set; }

    [BsonElement("apartment_id")]
    public int ApartmentId { get; set; }

    [BsonElement("price")]
    public decimal Price { get; set; }

}
