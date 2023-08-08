using AutoMapper;
using TestTask.Data.Dtos;
using TestTask.Data.Entities;

namespace TestTask.Data.MappingProfiles {
    public class MeteringDeviceProfile : Profile {
        public MeteringDeviceProfile() {
            CreateMap<Measure, MeteringDeviceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DeliveryPointId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DeliveryPoint.MeteringDeviceName));
        }
    }
}