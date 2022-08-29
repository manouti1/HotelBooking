using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Hotel { get; set; }
        [Required(ErrorMessage = "CheckIn date is required")]
        public BsonDateTime CheckIn { get; set; }
        [Required(ErrorMessage = "CheckOut date is required")]
        public BsonDateTime CheckOut { get; set; }
        public int Amount { get; set; }
        [Required(ErrorMessage = "Number of guests is required")]
        public int Guests { get; set; }
        [Required(ErrorMessage = "Number of nights is required")]
        public int Nights { get; set; }
        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
