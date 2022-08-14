using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerDetails { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel HotelDetails { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReviewedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
