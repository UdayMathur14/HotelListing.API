using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;
using HotelListing.API.Models.Users;

namespace HotelListing.API.Configuration
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateCountryDto , Country>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Country , UpdateCountryDto>().ReverseMap();
            CreateMap<GetCountryDto, Country>().ReverseMap();

            CreateMap<Hotel , CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();

            CreateMap<ApiUserDto , ApiUser>().ReverseMap();

        }
    }
}
