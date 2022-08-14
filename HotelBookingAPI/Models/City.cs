using System;

namespace HotelBookingAPI.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public bool IsActive { get; set; }
    }
}
