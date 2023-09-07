using Application.Contracts.Dtos;
using Application.Contracts.Dtos.User;
using AutoMapper;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper;
public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<WeatherDetailResponseDto, Data>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.WeatherMain, opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Main))
            .ForMember(dest => dest.WeatherDescription, opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Description))
            .ForMember(dest => dest.WeatherIcon, opt => opt.MapFrom(src => $"http://openweathermap.org/img/wn/{src.Weather.FirstOrDefault().ICon}@2x.png"))
            .ForMember(dest => dest.MainTemp, opt => opt.MapFrom(src => src.Main.Temp))
            .ForMember(dest => dest.MainHumidity, opt => opt.MapFrom(src => src.Main.Humidity)).ReverseMap();

        CreateMap<UserDto, User>().ReverseMap();

    }
}