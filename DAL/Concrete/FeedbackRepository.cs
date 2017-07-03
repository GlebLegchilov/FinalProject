using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DALInterface.DTO;
using ORM.Models;

namespace DAL.Concrete
{
    public class FeedbackRepository : Repository<DalFeedback, Feedback>
    {
        public FeedbackRepository(DbContext uow)
        {
            this.context = uow;
        }


        public override DalFeedback GetById(int key)
        {
            var entity = context.Set<Feedback>().FirstOrDefault(e => e.Id == key);
            return entity.ToDalFeedback();
        }



        public override void Create(DalFeedback e)
        {
            var entity = e.ToOrmFeedback();
            context.Set<Feedback>().Add(entity);
        }

        public override void Delete(int id)
        {
            var entity = context.Set<Feedback>().Single(c => c.Id == id);
            context.Set<Feedback>().Remove(entity);
        }

        public override void Update(DalFeedback entity)
        {
            Feedback ormEntity = context.Set<Feedback>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Feedback)entity.ToOrmFeedback());
        }

        public override IEnumerable<DalFeedback> GetByPredicate(Expression<Func<DalFeedback, bool>> predicate)
        {
            return GetOrmByPredicate(predicate).Select(e => e.ToDalFeedback());
        }
    }
}
