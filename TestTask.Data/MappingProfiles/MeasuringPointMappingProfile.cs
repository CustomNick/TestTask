using System;
using AutoMapper;
using TestTask.Data.Dtos;
using TestTask.Data.Entities;

namespace TestTask.Data.MappingProfiles {
    public class MeasuringPointMappingProfile : Profile {
        public MeasuringPointMappingProfile() {
            CreateMap<MeasuringPointDto, MeasuringPoint>()
                .ForMember(dest => dest.CounterCheckDate, opt => opt.MapFrom(
                    src => DateTimeOffset.FromUnixTimeMilliseconds(src.CounterCheckDateTimestamp)
                ))
                .ForMember(dest => dest.CurrentTransormatorCheckDate, opt => opt.MapFrom(
                    src => DateTimeOffset.FromUnixTimeMilliseconds(src.CurrentTransormatorCheckDateTimestamp)
                ))
                .ForMember(dest => dest.VoltageTransormatorCheckDate, opt => opt.MapFrom(
                    src => DateTimeOffset.FromUnixTimeMilliseconds(src.VoltageTransormatorCheckDateTimestamp)
                ));
        }
    }
}