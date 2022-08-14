using HotelBookingAPI.DBContext;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelBookingContext _dbContext;
        public HotelController(HotelBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<HotelDetails>> Get()
        {
            return new List<HotelDetails>();
        }
        [HttpGet]
        public ActionResult<List<HotelDetails>> Get(HotelFilter filter)
        {
            return new List<HotelDetails>();
        }
        [HttpGet]
        public ActionResult<HotelDetails> Get(int id)
        {
            return new HotelDetails();
        }
    }
}
