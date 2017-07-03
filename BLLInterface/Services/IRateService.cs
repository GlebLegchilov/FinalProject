using System.Collections.Generic;
using BLLInterface.Entities;

namespace BLLInterface.Services
{
    public interface IRateService
    {
        void AddRate(RateEntity newRate);

        void DeleteRate(int id);

        RateEntity GetMaxRate(int auctionId);

        IEnumerable<RateEntity> GetRates(int auctionId);
    }
}
