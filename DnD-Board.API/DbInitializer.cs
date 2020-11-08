using DnD_Board.Common.Constants;
using DnD_Board.Data.Models;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DnD_Board.API
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetService<IUnitOfWork>();
            if (unitOfWork.Repository<Role>().Count() != 0)
                return;

            var roleService = services.GetService<IRoleService>();
            var roles = new List<Role>
            {
                new Role { Name = DefaultRole.User },
                new Role { Name = DefaultRole.Admin }
            };
            roles.ForEach(role => roleService.CreateRole(role));
        }
    }
}
