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
        public bool Exist(RoleEntity c)
        {
            return uow.Roles.Exist(c.ToDalRole());
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            return uow.Roles.GetAll().Select(role=>role.ToBllRole());
        }

        public RoleEntity GetById(int roleId)
        {
            return uow.Roles.GetById(roleId).ToBllRole();
        }
    }
}
