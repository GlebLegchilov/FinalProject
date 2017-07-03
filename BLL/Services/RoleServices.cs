using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using DALInterface.DTO;

namespace BLL.Services
{
    public class RoleServices : IRoleService
    {
        private readonly IUnitOfWork uow;
        public RoleServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<RoleEntity> GetAllRoles()
        {
            return uow.Roles
                .GetByPredicate(r => true)
                .Select(r => r.ToBllRole());
        }

        public RoleEntity GetRole(int id)
        {
            return uow.Roles
                .GetById(id)
                .ToBllRole();
        }

        public RoleEntity GetRoleUser()
        {
            return uow.Roles
                .GetByPredicate(r => r.Name == "User")
                .First()
                .ToBllRole();
        }
    }
}
