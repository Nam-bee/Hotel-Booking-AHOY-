using HotelBookingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.RequestModel
{
    public class BookingRequest
    {
        public int CustomerId { get; set; }
        //key represents roomId and valude represents GuestCount
        public Dictionary<int, int> RoomDetails { get; set; }
        public DateOnly StayStartDate { get; set; }
        public DateOnly StayEndDate { get; set; }
        public double AmountPaid { get; set; }
    }
}
