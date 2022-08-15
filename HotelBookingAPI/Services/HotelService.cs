using HotelBookingAPI.DBContext;
using HotelBookingAPI.RequestModel;
using HotelBookingAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingContext _dbContext;
        public HotelService(HotelBookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<HotelDetails> GetHotelList(string cityName, string hotelName, int distance)
        {
            var hotels = string.IsNullOrEmpty(hotelName) ? _dbContext.Hotels
                .Include(a => a.HotelAddress)
                .Include(a=> a.HotelAddress.CityDetails)
                .ToList() :
                _dbContext.Hotels.Where(x=>x.HotelName.Trim().ToLower().Contains(hotelName.Trim().ToLower()))
                .Include(a => a.HotelAddress)
                .Include(a => a.HotelAddress.CityDetails)
                .ToList();
            var hoteldetails = new List<HotelDetails>();
            hotels.ForEach(x => hoteldetails.Add(new HotelDetails
            {
                HotelDetail = x,
                HotelImages = _dbContext.Images.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelReview = _dbContext.Reviews.Where(i => i.HotelId == x.HotelId).ToList(),
                HotelRooms = _dbContext.HotelRooms.Include(a => a.RoomDetails)
                .Where(i => i.HotelId == x.HotelId)
                .ToList(),
                HotelFacilities = _dbContext.HotelFacilities.Include(a => a.FacilityDetails)
                .Where(i => i.HotelId == x.HotelId)
                .ToList(),
                DestinationNearBy = _dbContext.Destinations.Where(i => i.CityId == x.HotelAddress.CityId).ToList(),
                Distance = DistanceCalculator.GetDistanceFromLatLonInKm(
                    x.HotelAddress.Latitude, x.HotelAddress.Longtitude,
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Latitude).FirstOrDefault(),
                    _dbContext.Cities.Where(i => i.CityId == x.HotelAddress.CityId).Select(x => x.Longtitude).FirstOrDefault()
                    )
            }));
            if (!string.IsNullOrEmpty(cityName))
            {
                var cityId = _dbContext.Cities.Where(x => x.CityName.ToLower().Equals(cityName.ToLower()))
                    .Select(x => x.CityId)
                    .FirstOrDefault();
                hoteldetails =  hoteldetails.Where(x => x.HotelDetail.HotelAddress.CityId == cityId).ToList();
            }
            if(distance > 0)
            {
                hoteldetails =  hoteldetails.Where(x => x.Distance <= distance).ToList();
            }
            return hoteldetails;
        }
        public HotelDetails GetHotelDetails(int hotelId)
        {
            var hotel = _dbContext.Hotels.Where(x=>x.HotelId == hotelId)
                .Include(a => a.HotelAddress)
                .Include(a => a.HotelAddress.CityDetails)
                .FirstOrDefault();
            var hoteldetail = new HotelDetails
            {
                HotelDetail = hotel,
                HotelImages = _dbContext.Images.Where(i => i.HotelId == hotel.HotelId).ToList(),
                HotelReview = _dbContext.Reviews.Where(i => i.HotelId == hotel.HotelId).ToList(),
                HotelRooms = _dbContext.HotelRooms.Include(a => a.RoomDetails)
                .Where(i => i.HotelId == hotel.HotelId)
                .ToList(),
                HotelFacilities = _dbContext.HotelFacilities.Include(a => a.FacilityDetails)
                .Where(i => i.HotelId == hotel.HotelId)
                .ToList(),
                DestinationNearBy = _dbContext.Destinations
                .Where(i => i.CityId == hotel.HotelAddress.CityId)
                .ToList(),
                Distance = DistanceCalculator.GetDistanceFromLatLonInKm(
                    hotel.HotelAddress.Latitude, hotel.HotelAddress.Longtitude,
                    _dbContext.Cities.Where(i => i.CityId == hotel.HotelAddress.CityId)
                    .Select(x => x.Latitude)
                    .FirstOrDefault(),
                    _dbContext.Cities.Where(i => i.CityId == hotel.HotelAddress.CityId)
                    .Select(x => x.Longtitude)
                    .FirstOrDefault()
                    )
            };
            return hoteldetail;
        }
    }
}
