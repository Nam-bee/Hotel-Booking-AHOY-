using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public int AddressId { get; set; }
        public string Description { get; set; }
        [ForeignKey("AddressId")]
        public Address HotelAddress { get; set; }
        public bool IsActive { get; set; }
        public int StarRating { get; set; }
        public List<Facility> HotelFacilities { get; set; }

    }
}
