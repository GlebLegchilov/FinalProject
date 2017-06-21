using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DALInterface.DTO;
using DALInterface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRepository<DalRole>
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

        public DalRole GetByName(string name)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Name == name);
            return ormRole.ToDalRole();
        }

        public bool Exist(DalRole e)
        {
            var entity = context.Set<Role>().FirstOrDefault(g => g.Id == e.Id);
            return entity.Name == e.Name;
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

        public void Update(DalRole entity)
        {
            Role ormEntity = context.Set<Role>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Role)entity.ToOrmRole());
        }
    }
}
