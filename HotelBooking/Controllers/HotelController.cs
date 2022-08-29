using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;
        private readonly RoomService _roomService;
        public HotelController(HotelService hService, RoomService rService)
        {
            _hotelService = hService;
            _roomService = rService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            var hotels = await _hotelService.GetAllHotelsAync();
            return Ok(hotels);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Hotel>> GetById(string id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            if (hotel.Rooms.Count > 0)
            {
                var tempList = new List<Room>();
                foreach (var roomId in hotel.Rooms)
                {
                    var room = await _roomService.GetByIdAsync(roomId);
                    if (room != null)
                        tempList.Add(room);
                }
                hotel.RoomList = tempList;
            }
            return Ok(hotel);
        }

    }
}
