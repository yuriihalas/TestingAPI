using AutoMapper;

namespace TestingApi.dto.profiles;

public class UserInfoProfile : Profile
{
    public UserInfoProfile()
    {
        CreateMap<UserInfoDto, UserInfo>()
            .ForMember(dest => dest.User, opt =>
                opt.MapFrom(src => src.data))
            .ForMember(dest => dest.Support, opt =>
                opt.MapFrom(src => src.support));
    }
}