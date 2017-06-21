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

        public LotServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool Exist(LotEntity lot)
        {
            return uow.Lots.Exist(lot.ToDalLot());
        }

        public LotEntity GetById(int id)
        {
            return uow.Lots.GetById(id).ToBllLot();
        }


        public IEnumerable<LotEntity> GetAll()
        {
            return uow.Lots.GetAll().Select(lot => lot.ToBllLot());
        }

        public void CreateLot(LotEntity lot)
        {
           

            
            uow.Lots.Create(lot.ToDalLot());
            uow.Commit();
        }

        public void DeleteLot(int id)
        {
            uow.Lots.Delete(uow.Lots.GetById(id));
            uow.Commit();
        }

        public void UdateLot(LotEntity lot)
        {
            uow.Lots.Update(lot.ToDalLot());
            uow.Commit();
        }

        public void BuyLot(int id,int owner)
        {
            var entity = uow.Lots.GetById(id);
            entity.OwnerId = owner;
            uow.Lots.Update(entity);
            uow.Commit();
        }

        public IEnumerable<LotEntity> GetPurchaseLot(string name)
        {
            var userId = uow.Users.GetByName(name).Id;
            return uow.Lots.GetAll().Where(l => l.OwnerId == userId).Select(l=>l.ToBllLot()); 
        }
        
        public IEnumerable<LotEntity> GetMyLots(string name)
        {
            var userId = uow.Users.GetByName(name).Id;
            return uow.Lots.GetAll().Where(l => l.CreatorId == userId).Select(l => l.ToBllLot());
        }

    }
}
