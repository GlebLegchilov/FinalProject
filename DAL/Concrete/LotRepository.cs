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
    public class LotRepository : Repository<DalLot, Lot>
    {

        public LotRepository(DbContext context)
        {
            this.context = context;
        }


        public override DalLot GetById(int key)
        {
            var ormLot = context.Set<Lot>().FirstOrDefault(lot => lot.Id == key);
            return ormLot.ToDalLot();
        }

        public override void Create(DalLot e)
        {
            var user = e.ToOrmLot();
            context.Set<Lot>().Add(user);
        }

        public override void Delete(int id)
        {
            var lot = context.Set<Lot>().Single(l => l.Id == id);
            context.Set<Lot>().Remove(lot);
        }

        public override void Update(DalLot entity)
        {
            Lot ormEntity = context.Set<Lot>().FirstOrDefault(e => e.Id == entity.Id);
            context.Entry(ormEntity).CurrentValues.SetValues((Lot)entity.ToOrmLot());
        }

        public override IEnumerable<DalLot> GetByPredicate(Expression<Func<DalLot, bool>> predicate)
        {
            return GetOrmByPredicate(predicate).Select(e => e.ToDalLot());
        }
    }
}
