namespace HotelBookingAPI.Models
{
    public class Reviews
    {
        public Guid ReviewId { get; set; }
        public Customer CustomerDetails { get; set; }
        public Hotel HotelDetails { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReviewedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
