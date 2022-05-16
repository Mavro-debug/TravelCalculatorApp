using AutoMapper;
using MileageKilometersTravelCalculatorApp.Domein.Models;

namespace MileageKilometersTravelCalculatorApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TravelResoult, TravelResoultDto>()
                .ForMember(m => m.Hours, opt => opt.MapFrom(src => src.TravelTime.Hours))
                .ForMember(m => m.Minutes, opt => opt.MapFrom(src => src.TravelTime.Minutes))
                .ForMember(m => m.FuelConsumption, opt => opt.MapFrom(src => src.FuelConsumption.Fuel))
                .ForMember(m => m.LPGConsumption, opt => opt.MapFrom(src => src.FuelConsumption.LPG))
                .ForMember(m => m.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}
