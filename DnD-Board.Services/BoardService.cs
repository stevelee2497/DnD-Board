using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.Services
{
    public class BoardService : IBoardService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BoardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Board CreateBoard(CreateBoardDto createBoardDto)
        {
            var board = _mapper.Map<Board>(createBoardDto);
            _unitOfWork.Repository<Board>().Add(board);
            _unitOfWork.Repository<BoardUser>().Add(new BoardUser { UserId = createBoardDto.UserId, BoardId = board.Id, MemberType = BoardMemberType.Admin });
            _unitOfWork.Complete();
            return board;
        }

        public IEnumerable<Board> GetBoards(BoardQuery query)
        {
            var res = _unitOfWork.Repository<Board>().Include(x => x.BoardUsers).ThenInclude(x => x.User);

            if (string.IsNullOrEmpty(query.Name))
                return res;

            return res.Where(x => x.Name.ToLower().Contains(query.Name.ToLower()));
        }

        public void DeleteBoard(Guid id)
        {
            var board = _unitOfWork.Repository<Board>().Find(id);
            _unitOfWork.Repository<Board>().Remove(board);
            _unitOfWork.Complete();
        }

        public Board UpdateBoard(Guid id, UpdateBoardDto dto)
        {
            var board = _unitOfWork.Repository<Board>().Find(id);

            board.ImageUrl = dto.ImageUrl;
            board.Name = dto.Name;
            board.PhaseOrder = JsonConvert.SerializeObject(dto.PhaseOrder);

            _unitOfWork.Repository<Board>().Update(board);
            _unitOfWork.Complete();

            return board;
        }

        public BoardUser CreateBoardUser(BoardUser boardUser)
        {
            _unitOfWork.Repository<BoardUser>().Update(boardUser);
            _unitOfWork.Complete();

            return boardUser;
        }

        public Board GetBoard(Guid id) => _unitOfWork.Repository<Board>().Find(id);
    }
}
