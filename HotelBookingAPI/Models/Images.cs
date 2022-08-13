namespace HotelBookingAPI.Models
{
    public class Images
    {
        public Guid ImageId { get; set; }
        public HotelRooms HotelRoomDetails { get; set; }
        public Hotel HotelDetails { get; set; }
        public string ImageContent { get; set; }
        public string ImageName { get; set; }
        public string FileType { get; set; }
        public bool IsActive { get; set; }
    }
}
