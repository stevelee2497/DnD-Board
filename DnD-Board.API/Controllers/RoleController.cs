using AutoMapper;
using DnD_Board.IServices;
using DnD_Board.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Produces("application/json")]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<RoleDto>> GetRoles()
        {
            return new SuccessResponse<IEnumerable<RoleDto>>(_roleService.GetRoles().Select(x => _mapper.Map<RoleDto>(x)));
        }
    }
}