using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterface.DTO;

namespace DALInterface.Repository
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<DalUser> Users { get; }
        IRepository<DalRole> Roles { get; }
        IRepository<DalLot> Lots { get; }
        IRepository<DalAuction> Auctions { get; }
        IRepository<DalFeedback> Feedbacks { get; }
        IRepository<DalRate> Rates { get; }

        void Commit();

    }
}
