﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class RoomBookingDetail
    {
        [Key]
        public int RoomBookingId { get; set; }
        public int BookingId { get; set; }
        public int HotelRoomId { get; set; }
        [ForeignKey("HotelRoomId")]
        public HotelRoom RoomDetails { get; set; }
        public int GuestCount { get; set; }
        public bool IsActive { get; set; }
    }
}
