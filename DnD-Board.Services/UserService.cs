using DnD_Board.Common.Constants;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.EntityFrameworkCore;
using System;
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
            _unitOfWork.Repository<User>().Add(user);

            var role = _unitOfWork.Repository<Role>().FirstOrDefault(x => x.Name == DefaultRole.User);
            _unitOfWork.Repository<UserRole>().Add(new UserRole { UserId = user.Id, RoleId = role.Id });

            _unitOfWork.Complete();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Repository<User>().Include(x => x.UserRoles).ThenInclude(x => x.Role);
        }

        public User GetUser(Guid id)
        {
            return _unitOfWork.Repository<User>().Find(id);
        }

        public User UpdateUser(Guid id, CreateUserDto userDto)
        {
            var user = _unitOfWork.Repository<User>().Find(id);

            user.AvatarUrl = userDto.AvatarUrl;
            user.DisplayName = userDto.DisplayName;

            _unitOfWork.Repository<User>().Update(user);
            _unitOfWork.Complete();

            return user;
        }

        public void DeleteUser(Guid id)
        {
            var user = _unitOfWork.Repository<User>().Find(id);
            _unitOfWork.Repository<User>().Remove(user);
            _unitOfWork.Complete();
        }
    }
}
