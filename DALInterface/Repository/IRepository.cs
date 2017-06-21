using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DALInterface.DTO;


namespace DALInterface.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        bool Exist(TEntity e);
        void Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity e);
    }
}
