using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Room type is required")]
        public decimal Price { get; set; }
        public int MaxGuests { get; set; } = 5;
        public bool IsAvailable { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
