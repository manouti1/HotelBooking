namespace HotelBooking.Configurations
{
    public interface IMongoDBSettings
    {
        string HotelCollectionName { get; set; }
        string RoomCollectionName { get; set; }
        string BookingCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}