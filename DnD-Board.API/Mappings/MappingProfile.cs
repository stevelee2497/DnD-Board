using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
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

            CreateMap<BoardUser, BoardUserDto>()
                .ForMember(
                    destination => destination.DisplayName,
                    map => map.MapFrom(source => source.User.DisplayName)
                )
                .ForMember(
                    destination => destination.AvatarUrl,
                    map => map.MapFrom(source => source.User.AvatarUrl)
                );

            CreateMap<CreateBoardDto, Board>();

            CreateMap<Board, BoardOutputDto>()
                .ForMember(
                    destination => destination.Users,
                    map => map.MapFrom(source => source.BoardUsers)
                );

            CreateMap<CreateTaskDto, Task>();
        }
    }
}
