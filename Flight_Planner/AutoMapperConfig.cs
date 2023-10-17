using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Models;

namespace Flight_Planner
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirportRequest, Airport>()
                .ForMember(airport => airport.Id, opt => opt.Ignore())
                .ForMember(airport => airport.Code, opt => opt.MapFrom(request => request.Airport));

                cfg.CreateMap<Airport, AirportRequest>()
                .ForMember(request => request.Airport, opt => opt.MapFrom(airport => airport.Code));

                cfg.CreateMap<FlightRequest, Flight>();
                cfg.CreateMap<Flight, FlightRequest>();

            });
            
            // only during development, validate your mappings; remove it before release
            #if DEBUG
            configuration.AssertConfigurationIsValid();
            #endif
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            return configuration.CreateMapper();
        }
    }
}
