using DnD_Board.Data.Models;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface IUserService
    {
        User CreateUser(User user);

        IEnumerable<User> GetUsers();
    }
}