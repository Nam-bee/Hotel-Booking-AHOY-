using HotelBookingAPI.Models;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;

namespace HotelBookingAPI.Services
{
    public interface IBookingService
    {
        public BookingResponse CreateBooking(BookingRequest bookingRequest);
    }
}
