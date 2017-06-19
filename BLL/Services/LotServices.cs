using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using DALInterface.DTO;

namespace BLL.Services
{
    public class LotServices: ILotService
    {
        private readonly IUnitOfWork uow;
        private readonly ILotRepository repository;

        public LotServices(IUnitOfWork uow, ILotRepository repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        public LotEntity GetById(int id)
        {
            return repository.GetById(id).ToBllLot();
        }


        public IEnumerable<LotEntity> GetAll()
        {
            return repository.GetAll().Select(lot => lot.ToBllLot());
        }

        public void CreateLot(LotEntity lot)
        {
            repository.Create(lot.ToDalLot());
            uow.Commit();
        }

        public void DeleteLot(LotEntity lot)
        {
            repository.Delete(lot.ToDalLot());
            uow.Commit();
        }

        public void UdateLot(LotEntity lot)
        {
            repository.Update(lot.ToDalLot());
            uow.Commit();
        }

        public void BuyLot(int id,int owner)
        {
            var entity = repository.GetById(id);
            entity.OwnerId = owner;
            repository.Update(entity);
            uow.Commit();
        }
    }
}
