using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace ResiPay.Model.Card
{

    public class CardViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("card_number")]
        [Required(ErrorMessage = "Card number is required.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be exactly 16 digits.")]
        public string CardNumber { get; set; }

        [BsonElement("cvc")]
        [Required(ErrorMessage = "CVV is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV must be exactly 3 digits.")]
        public string CVC { get; set; }

        [BsonElement("card_date")]
        public string Date { get; set; }

        [BsonElement("apartment_id")]
        public int ApartmentId { get; set; }

        [BsonElement("user_id")]
        [Required(ErrorMessage = "User ID can not be empty.")]
        public int UserId { get; set; }

    }
}
