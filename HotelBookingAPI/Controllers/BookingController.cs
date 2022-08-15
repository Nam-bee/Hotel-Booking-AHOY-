﻿using HotelBookingAPI.Models;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost]
        public ActionResult<BookingResponse> Post(BookingRequest bookingRequest)
        {
            return _bookingService.CreateBooking(bookingRequest);
        }
        [HttpGet]
        public ActionResult<List<Booking>> Get(int customerId)
        {
            return _bookingService.GetCustomerBookingDetails(customerId);
        }
        [HttpDelete]
        public ActionResult<int> Delete(int bookingId)
        {
            return _bookingService.CancelBooking(bookingId);
        }
    }
}
