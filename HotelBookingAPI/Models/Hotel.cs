namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Description { get; set; }
        public Address HotelAddress { get; set; }
        public bool IsActive { get; set; }
        public int StarRating { get; set; }

    }
}
