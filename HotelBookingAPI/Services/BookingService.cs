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
                TotalCost = CalculateTotalCost(bookingRequest.RoomDetails, (bookingRequest.StayEndDate- bookingRequest.StayStartDate).Days)
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

        public List<Booking> GetCustomerBookingDetails(int customerID)
        {
            return _dbContext.Bookings.Where(x => x.CustomerId == customerID)
                .Include(a => a.RoomDetails).ToList();
        }
        public int CancelBooking(int bookingId)
        {
            var booking =  _dbContext.Bookings.Where(x => x.CustomerId == bookingId).FirstOrDefault();
            booking.IsCancelled = true;
            _dbContext.SaveChanges();
            return booking.BookingId;
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
