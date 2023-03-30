using AutoMapper;

namespace TestingApi.dto.profiles;

public class SupportProfile : Profile
{
    public SupportProfile()
    {
        CreateMap<SupportDto, Support>()
            .ForMember(dest => dest.Text, opt =>
                opt.MapFrom(src => src.text))
            .ForMember(dest => dest.Url, opt =>
                opt.MapFrom(src => src.url));
    }
}