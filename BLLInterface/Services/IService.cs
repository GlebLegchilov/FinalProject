using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
