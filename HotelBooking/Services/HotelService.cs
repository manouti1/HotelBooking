using HotelBooking.Configurations;
using HotelBooking.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class HotelService
    {
        private readonly IMongoCollection<Hotel> _hotels;
        public HotelService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _hotels = database.GetCollection<Hotel>(settings.HotelCollectionName);
        }

        public async Task<List<Hotel>> GetAllHotelsAync()
        {
            return await _hotels.Find(s => true).ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(string id)
        {
            return await _hotels.Find<Hotel>(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
