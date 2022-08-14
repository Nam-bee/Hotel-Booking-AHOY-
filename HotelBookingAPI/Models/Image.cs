using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int HotelId { get; set; }
        public int HotelRoomId { get; set; }
        [ForeignKey("HotelRoomId")]
        public HotelRoom HotelRoomDetails { get; set; }
        [ForeignKey("HotelId")]
        public Hotel HotelDetails { get; set; }
        public string ImageContent { get; set; }
        public string ImageName { get; set; }
        public string FileType { get; set; }
        public bool IsActive { get; set; }
    }
}
