using AutoMapper;
using Domain.Models;
using Service.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>()
                .ForPath(dest => dest.ChassisCodeNumber,
                            opt => opt.MapFrom(src => src.Chassis.CodeNumber))
                .ForPath(dest => dest.ChassisDescription,
                            opt => opt.MapFrom(src => src.Chassis.Description))
                .ForPath(dest => dest.EngineCylindersNumber,
                            opt => opt.MapFrom(src => src.Engine.CylindersNumber))
                .ForPath(dest => dest.EngineDescription,
                            opt => opt.MapFrom(src => src.Engine.Description))
                .ReverseMap();

            CreateMap<Engine, EngineDTO>()
                .ForPath(dest => dest.Brands,
                            opt => opt.MapFrom(src => src.Cars.Select(c => c.Brand)))
                 .ReverseMap();
           
            CreateMap<Chassis, ChassisDTO>()
               .ForPath(dest => dest.Brands,
                            opt => opt.MapFrom(src => src.Cars.Select(c => c.Brand)))
                 .ReverseMap();
        }
    }
}
