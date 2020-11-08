using DnD_Board.Data.Models;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface IRoleService
    {
        Role CreateRole(Role role);

        IEnumerable<Role> GetRoles();
    }
}