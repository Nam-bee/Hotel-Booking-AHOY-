namespace HotelBookingAPI.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public Address AddressDetails { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
