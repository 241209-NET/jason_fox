using AutoMapper;
using RoutineTracker.API.DTO;

namespace RoutineTracker.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserOutDTO>().ReverseMap();
    }
}