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
        private readonly IRoleRepository repository;

        public RoleServices(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            return repository.GetAll().Select(role=>role.ToBllRole());
        }

        public RoleEntity GetById(int roleId)
        {
            return repository.GetById(roleId).ToBllRole();
        }
    }
}
