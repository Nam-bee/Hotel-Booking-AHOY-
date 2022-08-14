using HotelBookingAPI.DBContext;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;

namespace HotelBookingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingContext _dbContext;
        public HotelService(HotelBookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<HotelDetails> GetHotelList()
        {
            var hotels = _dbContext.Hotels.ToList();
            var hoteldetails = new List<HotelDetails>();
            hotels.ForEach(x => hoteldetails.Add(new HotelDetails
            {
                HotelDetail = x,
                HotelImages = _dbContext.Images.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelReview = _dbContext.Reviews.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelRooms = _dbContext.HotelRooms.Where(i => i.HotelId == x.HotelId).ToList(),
                DestinationNearBy = _dbContext.Destinations.Where(i => i.CityId == x.HotelAddress.CityId).ToList(),
                Distance = DistanceCalculator.GetDistanceFromLatLonInKm(
                    x.HotelAddress.Latitude, x.HotelAddress.Longtitude,
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Latitude).FirstOrDefault(),
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Longtitude).FirstOrDefault()
                    )
            }));
            return hoteldetails;
        }
        public List<HotelDetails> GetHotelList(HotelFilter filter)
        {
            var hotels = string.IsNullOrEmpty(filter.HotelName) ? _dbContext.Hotels.ToList() :
                _dbContext.Hotels.Where(x=>x.HotelName.Trim().ToLower().Contains(filter.HotelName.Trim().ToLower())).ToList();
            var hoteldetails = new List<HotelDetails>();
            hotels.ForEach(x => hoteldetails.Add(new HotelDetails
            {
                HotelDetail = x,
                HotelImages = _dbContext.Images.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelReview = _dbContext.Reviews.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelRooms = _dbContext.HotelRooms.Where(i => i.HotelId == x.HotelId).ToList(),
                DestinationNearBy = _dbContext.Destinations.Where(i => i.CityId == x.HotelAddress.CityId).ToList(),
                Distance = DistanceCalculator.GetDistanceFromLatLonInKm(
                    x.HotelAddress.Latitude, x.HotelAddress.Longtitude,
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Latitude).FirstOrDefault(),
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Longtitude).FirstOrDefault()
                    )
            }));
            if (!string.IsNullOrEmpty(filter.CityName))
            {
                var cityId = _dbContext.Cities.Where(x => x.CityName == filter.CityName).Select(x => x.CityId).FirstOrDefault();
                hoteldetails =  hoteldetails.Where(x => x.HotelDetail.HotelAddress.CityId == cityId).ToList();
            }
            if(filter.Distance != 0)
            {
                hoteldetails =  hoteldetails.Where(x => x.Distance <= filter.Distance).ToList();
            }
            return hoteldetails;
        }
        public HotelDetails GetHotelDetails(int hotelId)
        {
            var hotel = _dbContext.Hotels.Where(x=>x.HotelId == hotelId).FirstOrDefault();
            var hoteldetail = new HotelDetails
            {
                HotelDetail = hotel,
                HotelImages = _dbContext.Images.Where(i => i.HotelId == hotel.HotelId).ToList(),
                HotelReview = _dbContext.Reviews.Where(i => i.HotelId == hotel.HotelId).ToList(),
                HotelRooms = _dbContext.HotelRooms.Where(i => i.HotelId == hotel.HotelId).ToList(),
                DestinationNearBy = _dbContext.Destinations.Where(i => i.CityId == hotel.HotelAddress.CityId).ToList(),
                Distance = DistanceCalculator.GetDistanceFromLatLonInKm(
                    hotel.HotelAddress.Latitude, hotel.HotelAddress.Longtitude,
                    _dbContext.Cities.Where(i => i.CityId == hotel.HotelAddress.CityId).Select(x => x.Latitude).FirstOrDefault(),
                    _dbContext.Cities.Where(i => i.CityId == hotel.HotelAddress.CityId).Select(x => x.Longtitude).FirstOrDefault()
                    )
            };
            return hoteldetail;
        }
    }
}
