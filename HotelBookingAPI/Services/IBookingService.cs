using HotelBookingAPI.Models;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;

namespace HotelBookingAPI.Services
{
    public interface IBookingService
    {
        public BookingResponse CreateBooking(BookingRequest bookingRequest);
        public List<Booking> GetCustomerBookingDetails(int customerID);
        public int CancelBooking(int bookingId);
    }
}
