using ApiTaskManager.Dto;
using AutoMapper;

namespace ApiTaskManager.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto , User>();
    }
}