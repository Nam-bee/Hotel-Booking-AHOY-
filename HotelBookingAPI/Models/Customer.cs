using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address AddressDetails { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
