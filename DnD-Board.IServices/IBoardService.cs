using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using System;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface IBoardService
    {
        Board CreateBoard(CreateBoardDto createBoardDto);
        BoardUser CreateBoardUser(BoardUser boardUser);
        void DeleteBoard(Guid id);
        Board GetBoard(Guid id);
        IEnumerable<Board> GetBoards(BoardQuery query);
        Board UpdateBoard(Guid id, UpdateBoardDto dto);
    }
}
