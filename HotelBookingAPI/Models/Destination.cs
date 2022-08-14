using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Destination
    {
        public int DestintionId { get; set; }
        public string DestinationName { get; set; }
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image DestintionImage { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City DestinationCity { get; set; }
        public bool IsActive { get; set; }

    }
}
