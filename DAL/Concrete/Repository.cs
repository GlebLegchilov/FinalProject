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
    public abstract class Repository<TDalEntity, TOrmEntity> : IRepository<TDalEntity>
        where TOrmEntity : class, IOrmEntity
        where TDalEntity : IEntity
    {
        protected DbContext context;
        
        public abstract TDalEntity GetById(int key);
        public virtual bool Exist(Expression<Func<TDalEntity, bool>> predicate)
        {
            return GetByPredicate(predicate).FirstOrDefault() != null;
        }

        public abstract void Create(TDalEntity e);
        public abstract void Delete(int id);
        public abstract void Update(TDalEntity e);
        public abstract IEnumerable<TDalEntity> GetByPredicate(Expression<Func<TDalEntity, bool>> predicate);

        protected virtual IEnumerable<TOrmEntity> GetOrmByPredicate(Expression<Func<TDalEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException();

            ParameterExpression ormEntityParam = Expression.Parameter(typeof(TOrmEntity), predicate.Parameters[0].Name);

            var parameterTypeModifier = new DalToOrmExpressionModifier(ormEntityParam);
            Expression<Func<TOrmEntity, bool>> ormPredicate =
                (Expression<Func<TOrmEntity, bool>>)Expression.Lambda(parameterTypeModifier.Modify(predicate.Body), ormEntityParam);

            return context.Set<TOrmEntity>()
                .Where(ormPredicate)
                .AsEnumerable();
        }
    }
}
