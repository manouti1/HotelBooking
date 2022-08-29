using FluentValidation;
using HotelBooking.DTO;
using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _bookingService.GetAllBookingAync();
        }

        [HttpGet("{id}")]
        public async Task<Booking> GetById(string id)
        {
            return await _bookingService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<BaseResponseModel> CreateBooking([FromBody] Booking model)
        {

            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponseModel
                {
                    IsSuccess = ModelState.IsValid,
                    Error = "Something went wrong!"
                };
            }

            await _bookingService.CreateAsync(model);

            Response.StatusCode = (int)HttpStatusCode.Created;
            return new BaseResponseModel
            {
                IsSuccess = true
            };
        }

        [HttpPut("{id}")]
        public async Task<BaseResponseModel> UpdateBooking(string id, [FromBody] Booking model)
        {

            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BookingResponseModel
                {
                    IsSuccess = ModelState.IsValid,
                    Error = "Something went wrong!"
                };
            }
            await _bookingService.UpdateAsync(id, model);


            return new BaseResponseModel
            {
                IsSuccess = true,
            };
        }

        [HttpDelete("{id}")]
        public async Task DeleteBooking(string id)
        {
            await _bookingService.DeleteAsync(id);
        }

    }
}
