using System;
namespace HotelBookingAPI
{
    public static class DistanceCalculator
    {

        public static double GetDistanceFromLatLonInKm(double startLat, double startLon, double endLat, double endLon)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = Deg2rad(endLat-startLat);  // deg2rad below
            var dLon = Deg2rad(endLon-startLon);
            var a =
              Math.Sin(dLat/2) * Math.Sin(dLat/2) +
              Math.Cos(Deg2rad(startLat)) * Math.Cos(Deg2rad(endLat)) *
              Math.Sin(dLon/2) * Math.Sin(dLon/2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            var d = R * c; // Distance in km
            return d;
        }

        private static double Deg2rad(double deg)
        {
            return deg * (Math.PI/180);
        }
    }
}
