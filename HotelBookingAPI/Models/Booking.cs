using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerDetails { get; set; }
        public List<RoomBookingDetail> RoomDetails { get; set; }
        public DateTime BookedOn { get; set; }
        public DateOnly StayStartDate { get; set; }
        public DateOnly StayEndDate { get; set; }
        public double AmountPaid { get; set; }
        public double TotalCost { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
    }
}
