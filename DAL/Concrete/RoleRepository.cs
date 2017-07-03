using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DALInterface.DTO;
using DALInterface.Repository;
using ORM.Models;

namespace DAL.Concrete
{
    public class RoleRepository : Repository<DalRole, Role>
    {

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        public override DalRole GetById(int key)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return ormRole.ToDalRole();
        }

        public override void Create(DalRole e)
        {
            var user = e.ToOrmRole();
            context.Set<Role>().Add(user);
        }

        public override void Delete(int id)
        {
            var role = context.Set<Role>().Single(r => r.Id == id);
            context.Set<Role>().Remove(role);
        }

        public override void Update(DalRole entity)
        {
            Role ormEntity = context.Set<Role>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Role)entity.ToOrmRole());
        }

        public override IEnumerable<DalRole> GetByPredicate(Expression<Func<DalRole, bool>> predicate)
        {
            return GetOrmByPredicate(predicate).Select(e => e.ToDalRole());
        }
    }
}
