using Camping.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Camping.Models;

namespace Camping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private DataContext _data;
        public BookingController (DataContext data)
        {
            this._data = data;
        }
        [HttpPost("book")]
        public IActionResult BookSpot (int userId, int spotId)
        {
            var user = _data.GetUserById(userId);
            if (user != null)
            {
                var spot = _data.GetSpots().FirstOrDefault(e_spot => e_spot.spotId == spotId);
                if (spot != null)
                {
                    var booking = new Booking { UserId = userId, SpotId = spotId };
                    _data.AddBooking(booking);
                    return Ok("Booking successful");
                }
                else
                {
                    return NotFound("Spot not found");
                }
            }
            else
                return NotFound("User not found");
        }

        [HttpGet("myBooking")]
        public IActionResult MyBookings(int userId)
        {
            var bookings = _data.GetBookingByUser(userId);
            
            return Ok(bookings);
        }
    }
}
