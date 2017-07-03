using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DALInterface.DTO;
using ORM.Models;


namespace DALInterface.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int key);
        bool Exist(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity e);
        void Delete(int id);
        void Update(TEntity e);
    }
}
