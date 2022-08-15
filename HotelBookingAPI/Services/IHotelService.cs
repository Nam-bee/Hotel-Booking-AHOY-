using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;

namespace HotelBookingAPI.Services
{
    public interface IHotelService
    {
        //public List<HotelDetails> GetHotelList();
        public List<HotelDetails> GetHotelList(string cityName, string hotelName, int distance);
        public HotelDetails GetHotelDetails(int hotelId);
    }
}
