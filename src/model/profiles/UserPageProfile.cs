using AutoMapper;

namespace TestingApi.dto.profiles;

public class UserPageProfile : Profile
{
    public UserPageProfile()
    {
        CreateMap<UserPageDto, UserPage>()
            .ForMember(dest => dest.PageNumber, opt =>
                opt.MapFrom(src => src.page))
            .ForMember(dest => dest.ResultsPerPage, opt =>
                opt.MapFrom(src => src.per_page))
            .ForMember(dest => dest.Total, opt =>
                opt.MapFrom(src => src.total))
            .ForMember(dest => dest.TotalPages, opt =>
                opt.MapFrom(src => src.total_pages))
            .ForMember(dest => dest.Users, opt =>
                opt.MapFrom(src => src.data))
            .ForMember(dest => dest.Support, opt =>
                opt.MapFrom(src => src.support));
    }
}