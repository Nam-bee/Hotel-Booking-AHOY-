using HotelBookingAPI.DBContext;
using HotelBookingAPI.Models;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly HotelBookingContext _dbContext;
        public BookingService(HotelBookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookingResponse CreateBooking(BookingRequest bookingRequest)
        {
            var bookingId = _dbContext.Bookings.Max(x => x.BookingId)+1;
            var newBooking = new Booking
            {
                BookingId = bookingId,
                CustomerId = bookingRequest.CustomerId,
                AmountPaid = bookingRequest.AmountPaid,
                StayEndDate = bookingRequest.StayEndDate,
                StayStartDate = bookingRequest.StayStartDate,
                BookedOn = DateTime.UtcNow,
                IsActive =true,
                IsCancelled =false,
                TotalCost = CalculateTotalCost(bookingRequest.RoomDetails, DaysDifference(bookingRequest.StayEndDate, bookingRequest.StayStartDate))
            };
            _dbContext.Bookings.Add(newBooking);
            CreateBookingRoomDetails(bookingId, bookingRequest.RoomDetails);
            _dbContext.SaveChanges();
            return new BookingResponse { 
            AmountPaid = newBooking.AmountPaid,
            BookingId = newBooking.BookingId,
            TotalCost = newBooking.TotalCost
            };
        }

        private double CalculateTotalCost(Dictionary<int, int> roomDetails, int days)
        {
            var totalCost = 0.0;
            foreach (var detail in roomDetails)
            {
                var room = _dbContext.HotelRooms.Where(x => x.HotelRoomId == detail.Key).Include(a => a.RoomDetails).FirstOrDefault();
                totalCost +=  room.CostPerNight * days;
                if (detail.Value > 2)
                {
                    totalCost += room.CostPerAddonGuest * days * (detail.Value - 2);
                }
            }
            return totalCost;
        }

        private int DaysDifference(DateOnly dateOnly1, DateOnly dateOnly2)
        {
            return (new DateTime(dateOnly1.Year, dateOnly1.Month, dateOnly1.Day) - new DateTime(dateOnly2.Year, dateOnly2.Month, dateOnly2.Day)).Days;
        }

        private void CreateBookingRoomDetails(int bookingId, Dictionary<int, int> roomDetails)
        {
            foreach (var detail in roomDetails)
            {
                var roombookingId = _dbContext.RoomBookingDetails.Max(x => x.RoomBookingId)+1;
                _dbContext.RoomBookingDetails.Add(
                    new RoomBookingDetail
                    {
                        BookingId = bookingId,
                        HotelRoomId = detail.Key,
                        GuestCount = detail.Value,
                        RoomBookingId = roombookingId,
                        IsActive = true
                    }
                    );
            }

        }
    }
}
