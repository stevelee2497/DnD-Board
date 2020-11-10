using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.API.Controllers
{
    [Route("api/boards")]
    [ApiController]
    [Produces("application/json")]
    public class BoardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService, IMapper mapper)
        {
            _mapper = mapper;
            _boardService = boardService;
        }

        [HttpPost]
        public SuccessResponse<BoardOutputDto> Create([FromBody] CreateBoardDto boardInputDto)
        {
            var res = _boardService.CreateBoard(boardInputDto);
            return new SuccessResponse<BoardOutputDto>(_mapper.Map<BoardOutputDto>(res));
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<BoardOutputDto>> Get([FromQuery] BoardQuery query)
        {
            var res = _boardService.GetBoards(query).Select(_mapper.Map<BoardOutputDto>);
            return new SuccessResponse<IEnumerable<BoardOutputDto>>(res);
        }

        [HttpGet("{id}")]
        public SuccessResponse<BoardOutputDto> Get(Guid id)
        {
            var res = _boardService.GetBoard(id);
            return new SuccessResponse<BoardOutputDto>(_mapper.Map<BoardOutputDto>(res));
        }

        [HttpPut("{id}")]
        public BaseResponse<BoardOutputDto> Update([FromBody] UpdateBoardDto boardDto, Guid id)
        {
            var res = _boardService.UpdateBoard(id, boardDto);
            return new SuccessResponse<BoardOutputDto>(_mapper.Map<BoardOutputDto>(res));
        }

        [HttpDelete("{id}")]
        public SuccessResponse<string> Delete(Guid id)
        {
            _boardService.DeleteBoard(id);
            return new SuccessResponse<string>("success");
        }

        [HttpPost("{id}/users")]
        public SuccessResponse<BoardUserDto> CreateBoardUser([FromBody] CreateBoardUserDto boardUserDto, Guid id)
        {
            var model = new BoardUser { BoardId = id, UserId = boardUserDto.UserId, MemberType = BoardMemberType.Member };
            var res = _boardService.CreateBoardUser(model);
            return new SuccessResponse<BoardUserDto>(_mapper.Map<BoardUserDto>(res));
        }
    }
}