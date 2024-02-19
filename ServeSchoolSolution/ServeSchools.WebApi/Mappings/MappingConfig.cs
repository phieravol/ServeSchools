using AutoMapper;
using ServeSchools.Application.DTOs;
using ServeSchools.Domain.Schools;

namespace ServeSchools.WebApi.Mappings
{
    public class MappingConfig: Profile
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateSchoolDTO, School>()
                    .ForMember(dest => dest.Name, otp => otp.MapFrom(dest => dest.Name))
                    .ForMember(dest => dest.CreatedDate, otp => otp.MapFrom(dest => DateTime.UtcNow))
                    .ForMember(dest => dest.FoundingDate, otp => otp.MapFrom(dest => dest.FoundingDate))
                    .ReverseMap();

                config.CreateMap<UpdateSchoolDTO, School>()
                    .ForMember(dest => dest.Id, otp => otp.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LastUpdated, otp => otp.MapFrom(src => DateTime.UtcNow))
                    .ForMember(dest => dest.FoundingDate, otp => otp.MapFrom(src => src.FoundingDate));
            });
            return mapperConfig.CreateMapper();
        }


    }
}
