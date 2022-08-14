using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class HotelRoom
    {
        public int HotelRoomId { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel HotelDetails { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomType RoomDetails { get; set; }
        public double CostPerNight { get; set; }
        public double CostPerAddonGuest { get; set; }
        public bool IsActive { get; set; }
    }
}
