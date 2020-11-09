using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.IServices;
using DnD_Board.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<UserDto>> GetUsers()
        {
            return new SuccessResponse<IEnumerable<UserDto>>(_userService.GetUsers().Select(x => _mapper.Map<UserDto>(x)));
        }

        [HttpPost]
        public SuccessResponse<UserDto> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var response = _userService.CreateUser(user);
            return new SuccessResponse<UserDto>(_mapper.Map<UserDto>(response));
        }
    }
}