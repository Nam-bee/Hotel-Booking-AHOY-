namespace HotelBookingAPI.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Customer CustomerDetails { get; set; }
        public List<HotelRooms> RoomDetails { get; set; }
        public int GuestCount { get; set; }
        public DateTime BookedOn { get; set; }
        public DateOnly StayStartDate { get; set; }
        public DateOnly StayEndDate { get; set; }
        public double AmountPaid { get; set; }
        public double TotalCost { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
    }
}
