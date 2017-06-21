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
    public class CategoryRepository : IRepository<DalCategory>
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

        public DalCategory GetByName(string name)
        {
            var ormCategory = context.Set<Category>().FirstOrDefault(category => category.Name == name);
            return ormCategory.ToDalCategory();
        }

        public bool Exist(DalCategory e)
        {
            var entity = context.Set<Category>().FirstOrDefault(g => g.Id == e.Id);
            return entity.Name == e.Name;
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

        public void Update(DalCategory entity)
        {
            Category ormEntity = context.Set<Category>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Category)entity.ToOrmCategory());
        }
    }
}
