using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public bool IsActive { get; set; }
    }
}
