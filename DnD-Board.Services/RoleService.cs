using DnD_Board.Data.Models;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using System.Collections.Generic;

namespace DnD_Board.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Role CreateRole(Role role)
        {
            var res = _unitOfWork.Repository<Role>().Add(role);
            _unitOfWork.Complete();
            return res;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _unitOfWork.Repository<Role>().All();
        }
    }
}
