using AutoMapper;

namespace TestingApi.dto.profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Id, opt =>
                opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Email, opt =>
                opt.MapFrom(src => src.email))
            .ForMember(dest => dest.FirstName, opt =>
                opt.MapFrom(src => src.first_name))
            .ForMember(dest => dest.LastName, opt =>
                opt.MapFrom(src => src.last_name))
            .ForMember(dest => dest.Avatar, opt =>
                opt.MapFrom(src => src.avatar));
    }
}