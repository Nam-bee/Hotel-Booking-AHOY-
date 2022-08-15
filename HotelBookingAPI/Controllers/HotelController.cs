using HotelBookingAPI.DBContext;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        //[HttpGet]
        //public ActionResult<List<HotelDetails>> Get()
        //{
        //    return _hotelService.GetHotelList();
        //}
        [HttpGet]
        public ActionResult<List<HotelDetails>> Get(string? cityName = null, string? hotelName = null, int? distance =0)
        {
            return _hotelService.GetHotelList(cityName, hotelName, distance.Value);
        }
        [HttpGet("{hotelId}")]
        public ActionResult<HotelDetails> Get(int hotelId)
        {
            return _hotelService.GetHotelDetails(hotelId);
        }
    }
}
