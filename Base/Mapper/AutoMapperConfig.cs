using AutoMapper;
using System;


namespace Base
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper;

        public static void Initialize()
        {

            var Config = new MapperConfiguration(Cfg =>
            {
                Cfg.CreateMap<JsonResponse.ResponseWeather, Response>()
                .ForMember(Dest => Dest.Temp, From => From.MapFrom(S => S.Main.Temp))
                .ForMember(Dest => Dest.MinTemp, From => From.MapFrom(S => S.Main.MinTemp))
                .ForMember(Dest => Dest.MaxTemp, From => From.MapFrom(S => S.Main.MaxTemp))
                .ForMember(Dest => Dest.Humidity, From => From.MapFrom(S => S.Main.Humidity))
                .ForMember(Dest => Dest.Pressure, From => From.MapFrom(S => S.Main.Pressure))
                .ForMember(Dest => Dest.Id, From => From.Ignore())
                .ForMember(Dest => Dest.CityName, From => From.MapFrom(S => S.Name))
                .ForMember(Dest => Dest.Date, From => From.MapFrom(S => DateTime.Now));
                //.ForMember(dest => dest.Status, from => from.MapFrom(s => "Querying"));
            });

            Mapper = Config.CreateMapper();

        }
    }
}
