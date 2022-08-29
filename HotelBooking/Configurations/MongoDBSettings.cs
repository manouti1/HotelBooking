namespace HotelBooking.Configurations
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string HotelCollectionName { get; set; }
        public string RoomCollectionName { get; set; }
        public string BookingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
