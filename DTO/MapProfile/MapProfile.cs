using AutoMapper;
using Domain.Model;
using DTO.Model;

namespace DTO.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Driver, DriverDTO>()
                .ReverseMap();
        }
    }
}
