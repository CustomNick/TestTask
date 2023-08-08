using AutoMapper;
using TestTask.Data.Dtos;
using TestTask.Data.Entities;

namespace TestTask.Data.MappingProfiles {
    public class CounterMappingProfile : Profile {
        public CounterMappingProfile() {
            CreateMap<MeasuringPoint, CounterDto>()
                .ForMember(
                    dest => dest.CounterCheckDateTimestamp,
                    opt => opt.MapFrom(src => src.CounterCheckDate.ToUnixTimeMilliseconds())
                );
        }
    }
}