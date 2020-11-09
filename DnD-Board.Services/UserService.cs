using DnD_Board.Common.Constants;
using DnD_Board.Data.Models;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DnD_Board.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CreateUser(User user)
        {
            var res = _unitOfWork.Repository<User>().Add(user);

            var role = _unitOfWork.Repository<Role>().FirstOrDefault(x => x.Name == DefaultRole.User);
            res.UserRoles.Add(new UserRole { UserId = res.Id, RoleId = role.Id });

            _unitOfWork.Complete();
            return res;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Repository<User>().Include(x => x.UserRoles).ThenInclude(x => x.Role);
        }
    }
}
