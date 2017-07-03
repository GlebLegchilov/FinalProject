using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using DALInterface.DTO;
using System;

namespace BLL.Services
{
    public class LotServices: ILotService
    {
        private readonly IUnitOfWork uow;

        public LotServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void BindLot(int lotId, int auctionId)
        {
            var lot = uow.Lots.GetById(lotId);
            lot.AuctionId = auctionId;
            uow.Lots.Update(lot);
            uow.Commit();
        }

        public void CreateLot(LotEntity entity)
        {
            uow.Lots.Create(entity.ToDalLot());
            uow.Commit();
        }

        public void DeleteLot(int id)
        {
            uow.Lots.Delete(id);
            uow.Commit();
        }

        public IEnumerable<LotEntity> GetAllLots()
        {
            return uow.Lots.GetByPredicate(l=>true).Select(l=>l.ToBllLot());
        }

        public LotEntity GetLot(string name)
        {
            return uow.Lots
                .GetByPredicate(l=>l.Name == name)
                .First()
                .ToBllLot();
        }

        public LotEntity GetLot(int id)
        {
            return uow.Lots.GetById(id).ToBllLot();
        }

        public IEnumerable<LotEntity> GetOwnerLots(int id)
        {
            return uow.Lots
                .GetByPredicate(l=>l.OwnerId == id)
                .Select(l=>l.ToBllLot());
        }

        public IEnumerable<LotEntity> GetOwnerLots(string name)
        {
            var id =  uow.Users.GetByPredicate(u => u.Name == name)
               .First()
               .ToBllUser()
               .Id;
            return uow.Lots
                .GetByPredicate(l => l.OwnerId == id)
                .Select(l => l.ToBllLot());
        }

        public bool IsExist(int id)
        {
            return uow.Lots.Exist(l=>l.Id == id);
        }

        public void UdateLot(LotEntity entity)
        {
            uow.Lots.Update(entity.ToDalLot());
            uow.Commit();
        }
    }
}
