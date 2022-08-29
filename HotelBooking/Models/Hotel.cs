using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Hotel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int Stars { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Rooms { get; set; }
        [BsonIgnore]
        public List<Room> RoomList { get; set; }


    }
}
