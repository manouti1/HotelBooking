using HotelBooking.Configurations;
using HotelBooking.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class RoomService
    {
        private readonly IMongoCollection<Room> _rooms;
        public RoomService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _rooms = database.GetCollection<Room>(settings.RoomCollectionName);
        }

        public async Task<List<Room>> GetAllHotelsAync()
        {
            return await _rooms.Find(s => true).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            return await _rooms.Find<Room>(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
