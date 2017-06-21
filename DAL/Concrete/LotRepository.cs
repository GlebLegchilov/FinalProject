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
    public class LotRepository : IRepository<DalLot>
    {
        private readonly DbContext context;

        public LotRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalLot> GetAll()
        {
            return context.Set<Lot>().AsEnumerable().Select(lot => lot.ToDalLot());
        }

        public DalLot GetById(int key)
        {
            var ormLot = context.Set<Lot>().FirstOrDefault(lot => lot.Id == key);
            return ormLot.ToDalLot();
        }

        public DalLot GetByName(string name)
        {
            var ormLot = context.Set<Lot>().FirstOrDefault(lot => lot.Name == name);
            return ormLot.ToDalLot();
        }

        public DalLot GetByPredicate(Expression<Func<DalLot, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalLot e)
        {

            var user = e.ToOrmLot();

            context.Set<Lot>().Add(user);
        }

        public bool Exist(DalLot e)
        {
            var entity = context.Set<Lot>().FirstOrDefault(lot => lot.Id == e.Id);
            if (entity == null) return false;
            return entity.Name == e.Name;
        }

        public void Delete(DalLot e)
        {
            var lot = e.ToOrmLot();
            lot = context.Set<Lot>().Single(l => l.Id == lot.Id);
            context.Set<Lot>().Remove(lot);
        }

        public void Update(DalLot entity)
        {
            Lot ormEntity = context.Set<Lot>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Lot)entity.ToOrmLot());
        }
    }
}
