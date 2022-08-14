using HotelBookingAPI.DBContext;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
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
    List<Hotel> hotels = new List<Hotel>{
        new Hotel { HotelId =1, Description = "Atlantis The Palm, Dubai is a luxury hotel resort located at the apex of the Palm Jumeirah in the United Arab Emirates. It was the first resort to be built on the island", AddressId =2, StarRating=5, IsActive = true },
        new Hotel { HotelId =2, Description = "In the heart of Dubai, Holiday Inn Bur Dubai - Embassy District is within a 5-minute drive of Dubai Museum and BurJuman Mall. This 4-star hotel is 2 mi (3.2 km) from Dubai Creek and 3 mi (4.9 km) from Dubai International Convention and Exhibition Centre. Make yourself at home in one of the 210 individually decorated guestrooms, featuring minibars and LCD televisions. ",
            AddressId =1, StarRating=4, IsActive = true },
        new Hotel { HotelId =3, Description = "Novotel World Trade Center is a 4-star luxury hotel less than 5 minutes walk from World Trade Center Metro Station (red line). Located off Sheihk Zayed Road, with 5 minutes to Burj Khalifa (world's tallest building), Dubai Frame, Dubai Financial Center and a few minutes to Jumeriah Beach and the Gold Souq.", AddressId =3, StarRating=4, IsActive = true },
    };
    context.Hotels.AddRange(hotels);
    List<RoomType> roomTypes = new List<RoomType>{
        new RoomType { RoomId = 1, RoomName = "Delux", RoomLengthInFeet = 15, RoomWidthInFeet=15, MaxAllowedPerson=3, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Suite", RoomLengthInFeet = 20, RoomWidthInFeet=20, MaxAllowedPerson=3, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Presidental Suite", RoomLengthInFeet = 30, RoomWidthInFeet=30, MaxAllowedPerson=4, IsActive = true },
        new RoomType { RoomId = 1, RoomName = "Private Villa", RoomLengthInFeet = 40, RoomWidthInFeet=40, MaxAllowedPerson=5, IsActive = true }
    };
    context.RoomTypes.AddRange(roomTypes);
    context.SaveChanges();

}

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
