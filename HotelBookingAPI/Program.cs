using HotelBookingAPI.DBContext;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Image = HotelBookingAPI.Models.Image;

var builder = WebApplication.CreateBuilder(args);

#region data Initialization
var contextOptions = new DbContextOptionsBuilder<HotelBookingContext>()
   .UseInMemoryDatabase(databaseName: "Test")
   .Options;

using (var context = new HotelBookingContext(contextOptions))
{
    List<City> cities = new List<City>{
        new City {CityId = 1, CityName= "Dubai", Latitude= 25.263056, Longtitude = 55.297222, IsActive = true },
        new City {CityId = 2, CityName= "Jebel Ali", Latitude= 25.01126, Longtitude = 55.06116, IsActive = true },
        new City {CityId = 3, CityName= "Sharjah", Latitude= 25.3575, Longtitude = 55.390833, IsActive = true },
        new City {CityId = 4, CityName= "Hatta", Latitude= 24.796667, Longtitude = 56.1175, IsActive = true }
       
    };
    context.Cities.AddRange(cities);
    List<Address> addresses = new List<Address>{
        new Address {AddressId =1, CityId = 1,DoorNumber = "204B", BuildingName="HolidayIn", Street="Bur Dubai",State="Dubai", Country="Dubai", Pincode="220609", Latitude= 25.256498974 , Longtitude = 55.306498774, IsActive = true },
        new Address {AddressId =2, CityId = 1,DoorNumber = "207B", BuildingName="Atlantis", Street="The Palm",State="Dubai", Country="Dubai", Pincode="220609", Latitude= 25.1252, Longtitude = 55.1170, IsActive = true },
        new Address {AddressId =3, CityId = 2,DoorNumber = "201B", BuildingName="Novotel", Street="New Market Street",State="Dubai", Country="Dubai", Pincode="220609", Latitude= 25.01116, Longtitude = 55.06156, IsActive = true },
        new Address {AddressId =4, CityId = 3,DoorNumber = "203B", BuildingName="Bella Vista", Street="Old Market Street",State="Sharjah", Country="Sharjah", Pincode="220709", Latitude= 25.5575, Longtitude = 55.790833, IsActive = true },
        new Address {AddressId =5, CityId = 4,DoorNumber = "202B", BuildingName="Old Residency", Street="Sunday Market",State="Dubai", Country="Dubai", Pincode="220609", Latitude= 23.796667, Longtitude = 56.9175, IsActive = true }

    };
    context.Addresses.AddRange(addresses);
    List<Customer> customers = new List<Customer>{
        new Customer { CustomerId=1, Name="Justin", DateOfBirth= new DateOnly(1993,7,18), AddressId =5, EmailId = "justin@demoahoy.com", ContactNumber="1234567", IsActive = true },
        new Customer { CustomerId=2, Name="Kate", DateOfBirth= new DateOnly(1995,3,18), AddressId =4, EmailId = "kate@demoahoy.com", ContactNumber="7654321", IsActive = true }
    };
    context.Customers.AddRange(customers);
    List<Facility> facilities = new List<Facility>{
        new Facility { FacilityId=1,FacilityName="Wifi", FacilityDescription = "Wifi Description", IsActive = true },
        new Facility { FacilityId=2,FacilityName="Parking", FacilityDescription = "Free Parking", IsActive = true },
        new Facility { FacilityId=3,FacilityName="Breakfast", FacilityDescription = "Wifi Breakfast", IsActive = true },
        new Facility { FacilityId=4,FacilityName="SPA", FacilityDescription = "Inhouse SPA", IsActive = true },
        new Facility { FacilityId=5,FacilityName="Swimming Pool", FacilityDescription = "Swimming Pool", IsActive = true },
       };
    context.Facilities.AddRange(facilities);
    List<Hotel> hotels = new List<Hotel>{
        new Hotel { HotelId =1,HotelName = "Atlantis", Description = "Atlantis The Palm, Dubai is a luxury hotel resort located at the apex of the Palm Jumeirah in the United Arab Emirates. It was the first resort to be built on the island", 
            HotelFacilities = facilities,AddressId =2, StarRating=5, IsActive = true },
        new Hotel { HotelId =2,HotelName = "Holiday Inn", Description = "In the heart of Dubai, Holiday Inn Bur Dubai - Embassy District is within a 5-minute drive of Dubai Museum and BurJuman Mall. This 4-star hotel is 2 mi (3.2 km) from Dubai Creek and 3 mi (4.9 km) from Dubai International Convention and Exhibition Centre. Make yourself at home in one of the 210 individually decorated guestrooms, featuring minibars and LCD televisions. ",
            HotelFacilities = facilities,AddressId =1, StarRating=4, IsActive = true },
        new Hotel { HotelId =3,HotelName = "Novotel", Description = "Novotel World Trade Center is a 4-star luxury hotel less than 5 minutes walk from World Trade Center Metro Station (red line). Located off Sheihk Zayed Road, with 5 minutes to Burj Khalifa (world's tallest building), Dubai Frame, Dubai Financial Center and a few minutes to Jumeriah Beach and the Gold Souq.",
            HotelFacilities = facilities, AddressId =3, StarRating=4, IsActive = true },
    };
    context.Hotels.AddRange(hotels);
    List<RoomType> roomTypes = new List<RoomType>{
        new RoomType { RoomId = 1, RoomName = "Delux", RoomLengthInFeet = 15, RoomWidthInFeet=15, MaxAllowedPerson=3, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Suite", RoomLengthInFeet = 20, RoomWidthInFeet=20, MaxAllowedPerson=3, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Presidental Suite", RoomLengthInFeet = 30, RoomWidthInFeet=30, MaxAllowedPerson=4, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Private Villa", RoomLengthInFeet = 40, RoomWidthInFeet=40, MaxAllowedPerson=5, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Exterior", IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Washroom", MaxAllowedPerson=5, IsActive = true }
    };
    context.RoomTypes.AddRange(roomTypes);
    List<HotelRoom> rooms = new List<HotelRoom>{
        new HotelRoom { HotelRoomId =1, HotelId=1, RoomId=1, CostPerNight=500, CostPerAddonGuest=200, IsActive = true },
        new HotelRoom { HotelRoomId =2, HotelId=1, RoomId=2, CostPerNight=600, CostPerAddonGuest=250, IsActive = true },
        new HotelRoom { HotelRoomId =3, HotelId=1, RoomId=3, CostPerNight=700, CostPerAddonGuest=300, IsActive = true },
        new HotelRoom { HotelRoomId =4, HotelId=1, RoomId=4, CostPerNight=800, CostPerAddonGuest=350, IsActive = true },
        new HotelRoom { HotelRoomId =5, HotelId=2, RoomId=1, CostPerNight=500, CostPerAddonGuest=200, IsActive = true },
        new HotelRoom { HotelRoomId =6, HotelId=2, RoomId=2, CostPerNight=600, CostPerAddonGuest=250, IsActive = true },
        new HotelRoom { HotelRoomId =7, HotelId=2, RoomId=3, CostPerNight=700, CostPerAddonGuest=300, IsActive = true },
        new HotelRoom { HotelRoomId =8, HotelId=2, RoomId=4, CostPerNight=800, CostPerAddonGuest=350, IsActive = true },
        new HotelRoom { HotelRoomId =9, HotelId=3, RoomId=1, CostPerNight=500, CostPerAddonGuest=200, IsActive = true },
        new HotelRoom { HotelRoomId =10, HotelId=3, RoomId=2, CostPerNight=600, CostPerAddonGuest=250, IsActive = true },
        new HotelRoom { HotelRoomId =11, HotelId=3, RoomId=3, CostPerNight=700, CostPerAddonGuest=300, IsActive = true },
        new HotelRoom { HotelRoomId =12, HotelId=4, RoomId=4, CostPerNight=800, CostPerAddonGuest=350, IsActive = true },
        new HotelRoom { HotelRoomId =13, HotelId=1, RoomId=5, IsActive = true },
        new HotelRoom { HotelRoomId =14, HotelId=1, RoomId=6, IsActive = true },
        new HotelRoom { HotelRoomId =15, HotelId=2, RoomId=5, IsActive = true },
        new HotelRoom { HotelRoomId =16, HotelId=2, RoomId=6, IsActive = true },
        new HotelRoom { HotelRoomId =17, HotelId=3, RoomId=5, IsActive = true },
        new HotelRoom { HotelRoomId =18, HotelId=3, RoomId=6, IsActive = true }
    };
    context.HotelRooms.AddRange(rooms);
    List<Booking> bookings = new List<Booking>{
        new Booking { BookingId=1, CustomerId=1, 
            RoomDetails = new List<HotelRoom>{ rooms.Where(x=>x.RoomId == 2).FirstOrDefault(),
                rooms.Where(x=>x.RoomId == 3).FirstOrDefault() }, 
            GuestCount = 2, BookedOn = new DateTime(2022,07,16), 
            StayStartDate= new DateOnly(2022,07,19), StayEndDate= new DateOnly(2022,07,21),AmountPaid = 1100, 
            TotalCost = 1100, IsCancelled = false, IsActive = false },
        new Booking { BookingId=2, CustomerId=3,
            RoomDetails = new List<HotelRoom>{ rooms.Where(x=>x.RoomId == 5).FirstOrDefault(),
                rooms.Where(x=>x.RoomId == 6).FirstOrDefault() },
            GuestCount = 2, BookedOn = new DateTime(2022,07,16),
            StayStartDate= new DateOnly(2022,08,31), StayEndDate= new DateOnly(2022,9,2),AmountPaid = 500,
            TotalCost = 900, IsCancelled = false, IsActive = true }
    };
    context.Bookings.AddRange(bookings);
    
    List<Image> images = new List<Image>{
        new Image { ImageId=1, HotelId=2, HotelRoomId=5, ImageContent="Delux Room", ImageName="HolidayInnDelux", FileType="jpg", IsActive = true },
        new Image { ImageId=2, HotelId=2, HotelRoomId=6, ImageContent="Suite Room", ImageName="HolidayInnSuite", FileType="jpg", IsActive = true },
        new Image { ImageId=3, HotelId=2, HotelRoomId=7, ImageContent="Presidential Suite Room", ImageName="HolidayInnPresedentalSuite", FileType="jpg", IsActive = true },
        new Image { ImageId=4, HotelId=2, HotelRoomId=8, ImageContent="Villa", ImageName="HolidayInnVilla", FileType="jpg", IsActive = true },
        new Image { ImageId=5, HotelId=2, HotelRoomId=16, ImageContent="Wash Room", ImageName="HolidayInnWashroom", FileType="jpg", IsActive = true },
        new Image { ImageId=6, HotelId=2, HotelRoomId=15, ImageContent="Exterior", ImageName="HolidayInnExterior", FileType="jpg", IsActive = true },
        new Image { ImageId=7, HotelId=3, HotelRoomId=9, ImageContent="Delux Room", ImageName="NovotelDelux", FileType="jpg", IsActive = true },
        new Image { ImageId=8, HotelId=3, HotelRoomId=10, ImageContent="Suite Room", ImageName="NovotelSuite", FileType="jpg", IsActive = true },
        new Image { ImageId=9, HotelId=3, HotelRoomId=11, ImageContent="Presidential Suite Room", ImageName="NovotelPresedentalSuite", FileType="jpg", IsActive = true },
        new Image { ImageId=10, HotelId=3, HotelRoomId=12, ImageContent="Villa", ImageName="NovotelVilla", FileType="jpg", IsActive = true },
        new Image { ImageId=11, HotelId=3, HotelRoomId=18, ImageContent="Wash Room", ImageName="NovotelWashroom", FileType="jpg", IsActive = true },
        new Image { ImageId=12, HotelId=3, HotelRoomId=17, ImageContent="Exterior", ImageName="NovotelExterior", FileType="jpg", IsActive = true },
        new Image { ImageId=13, ImageContent="Burj Khalifa", ImageName="Burjkhalifa", FileType="jpg", IsActive = true },
        new Image { ImageId=14, ImageContent="Dubai Mall", ImageName="DubaiMall", FileType="jpg", IsActive = true }
    };
    context.Images.AddRange(images);
    List<Review> reviews = new List<Review>{
        new Review { ReviewId=1, CustomerId=1, HotelId=2, Rating=4, Description="Best stay ever", ReviewedOn = new DateTime(2022,07,31), IsActive = true },    
    };
    context.Customers.AddRange(customers);
    List<Destination> destinations = new List<Destination>{
        new Destination { DestintionId=1, CityId = 1, DestinationName="Burj Khalifa", ImageId=13, IsActive = true },
        new Destination { DestintionId=2, CityId = 1, DestinationName="Dubai Mall", ImageId=14, IsActive = true }
    };
    context.Destinations.AddRange(destinations);
    context.SaveChanges();

}
#endregion data Initialization 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<HotelBookingContext>( options => options.UseInMemoryDatabase("Test"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
