using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface ILotService
    {
        void CreateLot(LotEntity entity);
        void DeleteLot(int id);
        void UdateLot(LotEntity entity);

        LotEntity GetLot(int id);
        LotEntity GetLot(string name);
        IEnumerable<LotEntity> GetOwnerLots(int id);
        IEnumerable<LotEntity> GetOwnerLots(string name);
        IEnumerable<LotEntity> GetAllLots();

        void BindLot(int lotId, int auctionId);

        bool IsExist(int id);

    }
}
