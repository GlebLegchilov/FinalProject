using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DALInterface.DTO;
using DALInterface.Repository;
using ORM.Models;

namespace DAL.Concrete
{
    public class UserRepository : Repository<DalUser, User>
    {

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public override DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return ormuser.ToDalUser(); 
        }


        public override void Create(DalUser e)
        {
            var user = e.ToOrmUser();        
            context.Set<User>().Add(user);
        }

        public override void Delete(int id)
        {
            var user = context.Set<User>().Single(u => u.Id == id);
            context.Set<User>().Remove(user);
        }

        public override void Update(DalUser entity)
        {
            User ormEntity = context.Set<User>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((User)entity.ToOrmUser());
        }

        public override IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            return GetOrmByPredicate(predicate).Select(e => e.ToDalUser());
        }
    }
}
