using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class RoomType
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomLengthInFeet { get; set; }
        public int RoomWidthInFeet { get; set; }
        public int MaxAllowedPerson { get; set; }
        public bool IsActive { get; set; }
    }
}
