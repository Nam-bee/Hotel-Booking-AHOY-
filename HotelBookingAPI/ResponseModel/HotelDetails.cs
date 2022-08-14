using HotelBookingAPI.Models;

namespace HotelBookingAPI.ResponseModel
{
    public class HotelDetails
    {
        public Hotel HotelDetail { get; set; }
        public List<Review> HotelReview { get; set; }
        public List<Image> HotelImages { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
        public List<Destination> DestinationNearBy { get; set; }
        public double Distance { get; set; }
    }
}
