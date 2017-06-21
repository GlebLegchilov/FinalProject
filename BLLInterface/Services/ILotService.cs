using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface ILotService:IService<LotEntity>
    {
        void CreateLot(LotEntity entity);
        void DeleteLot(int id);
        void UdateLot(LotEntity entity);
        void BuyLot(int id, int owner);
        IEnumerable<LotEntity> GetPurchaseLot(string name);

        IEnumerable<LotEntity> GetMyLots(string name);

    }
}
