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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            
            
            return context.Set<User>().AsEnumerable().Select(user => user.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return ormuser.ToDalUser(); 
        }
        public DalUser GetByName(string name)
        {
            
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Name == name);
            return ormuser.ToDalUser();
        }

        public bool Exist(DalUser e)
        {
            var entity = context.Set<User>().FirstOrDefault(g => g.Id == e.Id);
            return entity.Name == e.Name;
        }

        public void Create(DalUser e)
        {
            var user = e.ToOrmUser();        
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            var user = e.ToOrmUser(); 
            user = context.Set<User>().Single(u => u.Id == user.Id);
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            User ormEntity = context.Set<User>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((User)entity.ToOrmUser());
        }
    }
}
