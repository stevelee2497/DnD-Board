using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using System;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface IUserService
    {
        User CreateUser(User user);

        void DeleteUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers();

        User UpdateUser(Guid id, CreateUserDto userDto);
    }
}