using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DALInterface.DTO;
using DALInterface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().AsEnumerable().Select(role => role.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return ormRole.ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalRole e)
        {
            var user = e.ToOrmRole();
            context.Set<Role>().Add(user);
        }

        public void Delete(DalRole e)
        {
            var role = e.ToOrmRole();
            role = context.Set<Role>().Single(r => r.Id == role.Id);
            context.Set<Role>().Remove(role);
        }

        public void Update(DalRole e)
        {
            throw new NotImplementedException();
        }
    }
}
