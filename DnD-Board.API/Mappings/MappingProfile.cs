using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.Services.DTOs;
using System.Linq;

namespace DnD_Board.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDto>();

            CreateMap<User, UserDto>()
                .ForMember(
                    destination => destination.Roles,
                    map => map.MapFrom(source => source.UserRoles.Select(x => x.Role.Name))
                );

            CreateMap<CreateUserDto, User>();
        }
    }
}
