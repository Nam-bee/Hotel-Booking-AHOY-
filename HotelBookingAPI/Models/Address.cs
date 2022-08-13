namespace HotelBookingAPI.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string DoorNumber { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public City CityDetails { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public bool IsActive { get; set; }
    }
}
