using HotelBooking.Models;

namespace HotelBooking.DTO
{
    public class BookingResponseModel : BaseResponseModel
    {
        public Booking Response { get; set; }
    }
}
