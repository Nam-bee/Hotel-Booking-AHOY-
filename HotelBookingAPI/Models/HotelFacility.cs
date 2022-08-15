using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class HotelFacility
    {
        [Key]
        public int HotelFacilityId { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel HotelDetails { get; set; }
        public int FacilityId { get; set; }
        [ForeignKey("FacilityId")]
        public Facility FacilityDetails { get; set; }
        public bool IsActive { get; set; }
    }
}

