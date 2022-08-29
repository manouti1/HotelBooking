using HotelBooking.Configurations;
using HotelBooking.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class BookingService
    {
        private readonly IMongoCollection<Booking> _booking;
        public BookingService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _booking = database.GetCollection<Booking>(settings.BookingCollectionName);
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            await _booking.InsertOneAsync(booking);
            return booking;
        }

        public async Task DeleteAsync(string id)
        {
            await _booking.DeleteOneAsync(s => s.Id == id);
        }

        public async Task<List<Booking>> GetAllBookingAync()
        {
            return await _booking.Find(s => true).ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(string id)
        {
            return await _booking.Find<Booking>(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Booking booking)
        {
            await _booking.ReplaceOneAsync(s => s.Id == id, booking);
        }
    }
}
