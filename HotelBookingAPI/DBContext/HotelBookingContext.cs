using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.DBContext
{
    
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options)
            : base(options)
        { 
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
    }
}
