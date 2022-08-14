using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CityId { get; set; }
        public string DoorNumber { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        [ForeignKey("CityId")]
        public City CityDetails { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public bool IsActive { get; set; }
    }
}
