namespace HotelBookingAPI.Models
{
    public class RoomType
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomLengthInFeet { get; set; }
        public int RoomWidthInFeet { get; set; }
        public int MaxAllowedPerson { get; set; }
        public bool IsActive { get; set; }
    }
}
