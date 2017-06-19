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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext context;

        public CategoryRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalCategory> GetAll()
        {
            return context.Set<Category>().AsEnumerable().Select(role => role.ToDalCategory());
        }

        public DalCategory GetById(int key)
        {
            var ormCategory = context.Set<Category>().FirstOrDefault(category => category.Id == key);
            return ormCategory.ToDalCategory();
        }

        public DalCategory GetByPredicate(Expression<Func<DalCategory, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalCategory e)
        {
            var user = e.ToOrmCategory();
            context.Set<Category>().Add(user);
        }

        public void Delete(DalCategory e)
        {
            var category = e.ToOrmCategory();
            category = context.Set<Category>().Single(c => c.Id == category.Id);
            context.Set<Category>().Remove(category);
        }

        public void Update(DalCategory e)
        {
            throw new NotImplementedException();
        }
    }
}
