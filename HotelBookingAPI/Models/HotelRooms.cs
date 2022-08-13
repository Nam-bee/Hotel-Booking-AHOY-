namespace HotelBookingAPI.Models
{
    public class HotelRooms
    {
        public Guid HotelRoomId { get; set; }
        public Hotel HotelDetails { get; set; }
        public RoomType RoomDetails { get; set; }
        public double CostPerNight { get; set; }
        public double CostPerAddonGuest { get; set; }
        public bool IsActive { get; set; }
    }
}
